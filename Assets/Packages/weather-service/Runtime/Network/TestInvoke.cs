using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using Unity.Plastic.Newtonsoft.Json;
using UnityEngine;
using WeatherService.Runtime.Data;
using WeatherService.Runtime.DTO;
using WeatherService.Runtime.Network.GetWeatherRequests;
using WeatherService.Runtime.Network.Interfaces;

namespace WeatherService.Runtime.Network
{
    public class TestInvoke : MonoBehaviour
    {
        private void Start()
        {
            var service = new WeatherService();
            var cancellationTokenSource = new CancellationTokenSource();
            service.Register(new OpenMeteoWeatherProvider());
            service.Register(new OpenWeatherWeatherProvider());

             service.GetWeather(33.33f, 33.33f, cancellationTokenSource).Forget();
        }

        
      
    }
}
