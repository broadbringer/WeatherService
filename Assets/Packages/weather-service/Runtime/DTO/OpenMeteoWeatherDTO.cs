using System;
using Unity.Plastic.Newtonsoft.Json;
using WeatherService.Runtime.Data;

namespace WeatherService.Runtime.DTO
{
    [Serializable]
    public class OpenMeteoWeatherDTO : IConvertableToWeather
    {
        public CurrentInfo current;

        [Serializable]
        public class CurrentInfo
        {
            [JsonProperty("temperature_2m")] public decimal Temperature { get; set; }

            [JsonProperty("relative_humidity_2m")] public decimal RelativeHumidity { get; set; }

            [JsonProperty("apparent_temperature")] public decimal ApparentTemperature { get; set; }

            [JsonProperty("rain")] public decimal Rain { get; set; }

            [JsonProperty("cloud_cover")] public decimal CloudCover { get; set; }

            [JsonProperty("snowfall")] public decimal Snowfall { get; set; }

            [JsonProperty("wind_speed_10m")] public decimal WindSpeed { get; set; }

            [JsonProperty("wind_direction_10m")] public decimal WindDirection { get; set; }

            [JsonProperty("wind_gusts_10m")] public decimal WindGusts { get; set; }
        }

        public WeatherData ConvertToWeather(WindMeasurementUnit windMeasurementUnit,
            TemperatureMeasurementUnit temperatureMeasurementUnit) =>
            new(current.Temperature, current.RelativeHumidity, current.ApparentTemperature, current.Rain,
                current.CloudCover, current.Snowfall, current.WindSpeed, current.WindDirection,
                current.WindGusts, windMeasurementUnit, temperatureMeasurementUnit);
    }
}