using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using UnityEngine;
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

        public async UniTask<string> GetJson(float latitude, float longitude, CancellationTokenSource cancellationTokenSource)
        {
            var url = BaseURL + SetRequestParams(latitude, longitude);

            var request = UnityWebRequest.Get(url).SendWebRequest();
            await UniTask.WaitUntil(() => request.isDone || cancellationTokenSource.IsCancellationRequested, cancellationToken: cancellationTokenSource.Token).SuppressCancellationThrow();
            
            if (request.webRequest.result is UnityWebRequest.Result.ConnectionError
                or UnityWebRequest.Result.ProtocolError)
                throw new Exception("Connection Error");

            if (cancellationTokenSource.IsCancellationRequested)
                throw new Exception("Operation were cancelled");

            return request.webRequest.downloadHandler.text;
        }
    }
}