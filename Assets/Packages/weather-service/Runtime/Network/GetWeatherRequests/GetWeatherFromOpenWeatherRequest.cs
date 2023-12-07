using System;
using Cysharp.Threading.Tasks;
using UnityEngine.Networking;
using WeatherService.Runtime.Network.Interfaces;

namespace WeatherService.Runtime.Network.GetWeatherRequests
{
    public class GetWeatherFromOpenWeatherRequest : GetWeatherRequest
    {
        private const string APIKey = "1d540708e90bf61d1f03787a60292739";

        protected override string BaseURL => "https://api.openweathermap.org/data/2.5/weather?";
        protected override string SetRequestParams(float latitude, float longitude) =>
            $"lat={latitude}&lon={longitude}&appid={APIKey}";
    }
}