using System;
using Packages.weather_service.Runtime.Data;

namespace Packages.weather_service.Runtime.DTO
{
    [Serializable]
    public class OpenMeteoWeatherData : IConvertableToWeather
    {
        public CurrentInfo current;

        [System.Serializable]
        public class CurrentInfo
        {
            public decimal temperature_2m;
            public decimal relative_humidity_2m;
            public decimal apparent_temperature;
            public decimal rain;
            public decimal showers;
            public decimal snowfall;
            public decimal wind_speed_10m;
            public decimal wind_direction_10m;
            public decimal wind_gusts_10m;
        }

        public Weather Convert() => 
            new(current.temperature_2m, current.relative_humidity_2m, current.apparent_temperature, current.rain, current.showers, current.snowfall, current.wind_speed_10m, current.wind_direction_10m, current.wind_gusts_10m);
    }

    public interface IConvertableToWeather
    {
        Weather Convert();
    }
}