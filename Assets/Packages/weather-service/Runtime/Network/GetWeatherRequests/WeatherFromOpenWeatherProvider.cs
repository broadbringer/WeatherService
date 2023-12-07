using System;
using Cysharp.Threading.Tasks;
using Runtime.Network.Interfaces;
using UnityEngine.Networking;

namespace Runtime.Network.GetWeatherRequests
{
    public class WeatherFromOpenWeatherProvider : IWeatherProvider
    {
        private const string APIKey = "1d540708e90bf61d1f03787a60292739";
        
        public string BaseURL => "https://api.openweathermap.org/data/2.5/weather?";
        
        public string GetJson()
        {
            throw new System.NotImplementedException();
        }

        public async UniTask<string> GetJson(float latitude, float longitude)
        {
            var url = BaseURL + SetRequestParams(latitude, longitude);
            
            var request = await UnityWebRequest.Get(url).SendWebRequest();
            
            if (request.result is UnityWebRequest.Result.ConnectionError or UnityWebRequest.Result.ProtocolError)
                throw new Exception("Connection Error");

            return request.downloadHandler.text;
        }

        private string SetRequestParams(float latitude, float longitude) =>
            $"lat={latitude}&lon={longitude}&appid={APIKey}";
    }
}