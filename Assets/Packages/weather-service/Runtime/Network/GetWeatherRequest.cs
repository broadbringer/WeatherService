using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Threading.Tasks;
using Cysharp.Threading.Tasks;
using Packages.weather_service.Runtime.Data;
using Packages.weather_service.Runtime.DTO;
using Packages.weather_service.Runtime.Network.GetWeatherRequests;
using Unity.Plastic.Newtonsoft.Json;
using Unity.Plastic.Newtonsoft.Json.Linq;
using UnityEngine;
using UnityEngine.Networking;

public class GetWeatherRequest : MonoBehaviour
{
    private void Start()
    {
        GetWeather();
    }

    private async UniTask GetWeather()
    {
        var request = new GetWeatherFromOpenMeteoRequest();

        var result = await request.GetJson(49.45f, 4.13f);
        
        OpenMeteoWeatherData weatherDataA = JsonConvert.DeserializeObject<OpenMeteoWeatherData>(result, new JsonSerializerSettings
        {
            FloatParseHandling = FloatParseHandling.Decimal
        });

        Weather weather = weatherDataA.Convert();
        Debug.Log(weather.Rain);
    }
}
