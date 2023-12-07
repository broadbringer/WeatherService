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

            var weatherProviderOne = new OpenMeteoWeatherProvider();
            var weatherProviderTwo = new OpenWeatherProvider();
            
            service.Register(weatherProviderOne);
            service.Register(weatherProviderTwo);

            service.GetWeather(33.33f, 33.33f);
        }

       
    
    
      
    }
}
