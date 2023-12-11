using System;
using Unity.Plastic.Newtonsoft.Json;
using UnityEngine.Serialization;
using WeatherService.Runtime.Data;

namespace WeatherService.Runtime.DTO
{
    [Serializable]
    public class OpenWeatherDTO : IConvertableToWeather
    {
        // пометить атрибутами.
        public MainInfo main;
        public WindInfo wind;
        public RainInfo rain;
        public SnowInfo snow;
        public CloudInfo clouds;

        [System.Serializable]
        public class MainInfo
        {
             [JsonProperty("temp")] public decimal Temperature { get; set; }

             [JsonProperty("humidity")] public decimal Humidity { get; set; }

             [JsonProperty("feels_like")] public decimal FeelsLike { get; set; }
        }

        [System.Serializable]
        public class WindInfo
        {
             [JsonProperty("speed")] public decimal Speed { get; set; }

            [JsonProperty("deg")] public decimal Deg { get; set; }

             [JsonProperty("gust")] public decimal Gust { get; set; }
        }

        [System.Serializable]
        public class RainInfo
        {
            [JsonProperty("_1h")] public decimal Rain { get; set; }
        }

        [Serializable]
        public class CloudInfo
        {
            [JsonProperty("all")] public decimal Clouds { get; set; }
        }

        [Serializable]
        public class SnowInfo
        {
            [JsonProperty("_1h")] public decimal Snow { get; set; }
        }


        public WeatherData ConvertToWeather(WindMeasurementUnit windMeasurementUnit,
            TemperatureMeasurementUnit temperatureMeasurementUnit)
        {
            var rainInfo = rain ?? new RainInfo();
            var windInfo = wind ?? new WindInfo();
            var snowInfo = snow ?? new SnowInfo();
            var cloudInfo = clouds ?? new CloudInfo();

            return new WeatherData(main.Temperature, main.Humidity, main.FeelsLike, rainInfo.Rain, cloudInfo.Clouds,
                snowInfo.Snow,
                windInfo.Speed,
                windInfo.Deg, windInfo.Gust, windMeasurementUnit, temperatureMeasurementUnit);
        }
    }
}