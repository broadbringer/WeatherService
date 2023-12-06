﻿using System;
using System.Globalization;
using Cysharp.Threading.Tasks;
using Packages.weather_service.Runtime.Network.Interfaces;
using UnityEngine;
using UnityEngine.Networking;

namespace Packages.weather_service.Runtime.Network.GetWeatherRequests
{
    public class GetWeatherFromOpenMeteoRequest : IGetWeatherRequest
    {
        public string BaseURL =>
            "https://api.open-meteo.com/v1/forecast?";

        private string SetRequestParams(float latitude, float longitude) =>
            $"latitude={latitude.ToString(CultureInfo.InvariantCulture)}&longitude={longitude.ToString(CultureInfo.InvariantCulture)}&current=temperature_2m,relative_humidity_2m,apparent_temperature,is_day,rain,showers,snowfall,wind_speed_10m,wind_direction_10m,wind_gusts_10m";

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
    }
}