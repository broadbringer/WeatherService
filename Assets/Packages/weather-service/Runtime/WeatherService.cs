using System;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using UnityEngine;
using WeatherService.Runtime.Data;
using WeatherService.Runtime.Network.Interfaces;

namespace WeatherService.Runtime
{
    public class WeatherService
    {
        private List<IWeatherProvider> _weatherProviders = new();

        public async UniTask<List<Weather>> GetWeather(float latitude, float longitude)
        {
            var weathers = new List<Weather>();

            var weatherTasks = _weatherProviders.Select(async wp =>
            {
                var weather = await wp.GetWeather(latitude, longitude);
                weathers.Add(weather);
            });
            await UniTask.WhenAll(weatherTasks);
            
            weathers.ForEach(w => Debug.Log(w.WindSpeed));

            return weathers;
        }
        
        public void Register<T>(T weatherProvider) where T : IWeatherProvider
        {
            if (_weatherProviders.Contains(weatherProvider))
            {
                throw new Exception($"You already have this provider with type {weatherProvider.GetType()}");
            }
            
            _weatherProviders.Add(weatherProvider);
        }
    }
}