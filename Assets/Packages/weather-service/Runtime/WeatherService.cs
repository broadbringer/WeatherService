using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Cysharp.Threading.Tasks;
using UnityEngine;
using WeatherService.Runtime.Data;
using WeatherService.Runtime.Network.Interfaces;

namespace WeatherService.Runtime
{
    public class WeatherService
    {
        //TODO Обернуть weather в отдельный класс, и добавить приоритетоность загрузки.
        private List<IWeatherProvider> _weatherProviders = new();

        private TemperatureMeasurementUnit _temperatureMeasurementUnit = TemperatureMeasurementUnit.Celsius;
        private WindMeasurementUnit _windMeasurementUnit = WindMeasurementUnit.MeterPerSecond;

        public void SetTemperatureMeasurementUnit(TemperatureMeasurementUnit @as) =>
            _temperatureMeasurementUnit = @as;
        public void SetWindMeasurementUnit(WindMeasurementUnit @as) =>
            _windMeasurementUnit = @as;
        
        public async UniTask<List<WeatherData>> GetWeather(float latitude, float longitude,
            CancellationTokenSource cancellationTokenSource, float maxWaitTimeInSeconds = 1000)
        {
            var weathers = new List<WeatherData>();
            var weatherTasks = GetWeatherTask(latitude, longitude, cancellationTokenSource, weathers);
            var waitMaxTimeTask = UniTask.Delay(TimeSpan.FromSeconds(maxWaitTimeInSeconds), cancellationToken: cancellationTokenSource.Token); //add cancellation token
            await UniTask.WhenAny(UniTask.WhenAll(weatherTasks), waitMaxTimeTask);

            cancellationTokenSource.Cancel();
            
            if (weathers.Count <= 0)
                return null;
            
            foreach (var weatherData in weathers)
            {
                var x =weatherData.GetWindDataIn(WindMeasurementUnit.MeterPerSecond);
                Debug.Log(x.WindSpeed);
            }
            
            return weathers;
        }

        public void Register(IWeatherProvider weatherProvider)
        {
            if (_weatherProviders.Contains(weatherProvider))
            {
                throw new Exception($"You already have this provider with type {weatherProvider.GetType()}");
                return;
            }

            _weatherProviders.Add(weatherProvider);
        }

        private IEnumerable<UniTask> GetWeatherTask(float latitude, float longitude,
            CancellationTokenSource cancellationTokenSource, List<WeatherData> weathers) =>
            _weatherProviders.Select(async wp =>
            {
                var weather = await wp.GetWeather(latitude, longitude, cancellationTokenSource, _windMeasurementUnit, _temperatureMeasurementUnit);
                weathers.Add(weather);
            });
    }
}