using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Networking;

public class GetWeatherRequest : MonoBehaviour
{
    private void Start()
    {
        

    }

    private async Task GetWeather()
    {
        var request =
            new UnityWebRequest(
                "https://api.open-meteo.com/v1/forecast?latitude=52.52&longitude=13.41&current=temperature_2m,wind_speed_10m&hourly=temperature_2m,relative_humidity_2m,wind_speed_10m");
    }
}
