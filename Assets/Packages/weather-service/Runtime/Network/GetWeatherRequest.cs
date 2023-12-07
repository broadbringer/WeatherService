using Cysharp.Threading.Tasks;
using Unity.Plastic.Newtonsoft.Json;
using UnityEngine;
using WeatherService.Runtime.Data;
using WeatherService.Runtime.DTO;
using WeatherService.Runtime.Network.GetWeatherRequests;

namespace WeatherService.Runtime.Network
{
    public class GetWeatherRequest : MonoBehaviour
    {
        private void Start()
        {
            GetWeather();

            GetAnotherWeather();
        }

        private async UniTask GetWeather()
        {
            var request = new WeatherFromOpenMeteoProvider();

            var result = await request.GetJson(49.45f, 4.13f);
        
            OpenMeteoWeatherDTO weatherDtoA = JsonConvert.DeserializeObject<OpenMeteoWeatherDTO>(result, new JsonSerializerSettings
            {
                FloatParseHandling = FloatParseHandling.Decimal
            });

            Weather weather = weatherDtoA.Convert();
            Debug.Log(weather.WindSpeed);
        }
    
    
        private async UniTask GetAnotherWeather()
        {
            var request = new WeatherFromOpenWeatherProvider();

            var result = await request.GetJson(49.45f, 4.13f);
        
            OpenWeatherDTO weatherDtoA = JsonConvert.DeserializeObject<OpenWeatherDTO>(result, new JsonSerializerSettings
            {
                FloatParseHandling = FloatParseHandling.Decimal
            });

            Weather weather = weatherDtoA.Convert();
        
            Debug.Log(weather.WindSpeed);
        }
    }
}
