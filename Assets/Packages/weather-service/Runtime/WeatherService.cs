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
        private Weather _weather = new();
        private List<IWeatherProvider> _providers = new();
        
        private TemperatureMeasurementUnit _temperatureMeasurementUnit = TemperatureMeasurementUnit.Celsius;
        private WindMeasurementUnit _windMeasurementUnit = WindMeasurementUnit.MeterPerSecond;

        public void SetTemperatureMeasurementUnit(TemperatureMeasurementUnit @as) =>
            _temperatureMeasurementUnit = @as;
        public void SetWindMeasurementUnit(WindMeasurementUnit @as) =>
            _windMeasurementUnit = @as;
        
        public async UniTask<Weather> GetWeather(float latitude, float longitude,
            CancellationTokenSource cancellationTokenSource, float maxWaitTimeInSeconds = 1000)
        {
            _weather.Clear();
            
            var weatherTasks = GetWeatherTask(latitude, longitude, cancellationTokenSource);
            var waitMaxTimeTask = UniTask.Delay(TimeSpan.FromSeconds(maxWaitTimeInSeconds), cancellationToken: cancellationTokenSource.Token); //add cancellation token
            await UniTask.WhenAny(UniTask.WhenAll(weatherTasks), waitMaxTimeTask);

            cancellationTokenSource.Cancel();
            
            if (_weather.WeatherProviderToWeatherDataMap.Count <= 0)
                return null;

            var value = _weather.GetValueFor(WeatherType.Temperature, WindMeasurementUnit.MeterPerSecond,
                TemperatureMeasurementUnit.Celsius);
            
            Debug.Log(value);
            
            return _weather;
        }

        public void Register(IWeatherProvider weatherProvider)
        {
            if (_providers.Contains(weatherProvider))
            {
                throw new Exception($"You already have this provider with type {weatherProvider.GetType()}");
                return;
            }

            _providers.Add(weatherProvider);
        }

        private IEnumerable<UniTask> GetWeatherTask(float latitude, float longitude,
            CancellationTokenSource cancellationTokenSource) =>
            _providers.Select(async wp =>
            {
                var weather = await wp.GetWeather(latitude, longitude, cancellationTokenSource, _windMeasurementUnit, _temperatureMeasurementUnit);
                _weather.Add(weather, wp);
            });
    }
}