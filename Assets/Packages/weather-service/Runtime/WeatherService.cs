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
        private List<IWeatherProvider> _weatherProviders = new();

        public async UniTask<List<Weather>> GetWeather(float latitude, float longitude,
            CancellationTokenSource cancellationTokenSource, float maxWaitTimeInSeconds)
        {
            var weathers = new List<Weather>();

            var weatherTasks = GetWeatherTask(latitude, longitude, cancellationTokenSource, weathers);
            
            var waitMaxTimeTask = UniTask.Delay(TimeSpan.FromSeconds(maxWaitTimeInSeconds));

            await UniTask.WhenAny(UniTask.WhenAll(weatherTasks), waitMaxTimeTask);
            
            if (weathers.Count <= 0)
                return null;

            weathers.ForEach(w => Debug.Log(w.WindSpeed));
            
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

        private IEnumerable<UniTask> GetWeatherTask(float latitude, float longitude, CancellationTokenSource cancellationTokenSource, List<Weather> weathers) =>
            _weatherProviders.Select(async wp =>
            {
                var weather = await wp.GetWeather(latitude, longitude, cancellationTokenSource);
                weathers.Add(weather);
            });
    }
}