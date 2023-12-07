using System;
using Cysharp.Threading.Tasks;
using UnityEngine.Networking;

namespace WeatherService.Runtime.Network.Interfaces
{
    public abstract class GetWeatherRequest
    {
        protected abstract string BaseURL { get; }
        protected abstract string SetRequestParams(float latitude, float longitude);

        public string GetJson()
        {
            return string.Empty;
        }

        public async UniTask<string> GetJson(float latitude, float longitude)
        {
            var url = BaseURL + SetRequestParams(latitude, longitude);

            var request = await UnityWebRequest.Get(url).SendWebRequest();

            if (request.result is UnityWebRequest.Result.ConnectionError or UnityWebRequest.Result.ProtocolError)
                throw new Exception("Connection Error");

            return request.downloadHandler.text;
        }
    }
}