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

        GetAnotherWeather();
    }

    private async UniTask GetWeather()
    {
        var request = new GetWeatherFromOpenMeteoRequest();

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
        var request = new GetWeatherFromOpenWeatherRequest();

        var result = await request.GetJson(49.45f, 4.13f);
        
        OpenWeatherDTO weatherDtoA = JsonConvert.DeserializeObject<OpenWeatherDTO>(result, new JsonSerializerSettings
        {
            FloatParseHandling = FloatParseHandling.Decimal
        });

        Weather weather = weatherDtoA.Convert();
        
        Debug.Log(weather.WindSpeed);
    }
}
