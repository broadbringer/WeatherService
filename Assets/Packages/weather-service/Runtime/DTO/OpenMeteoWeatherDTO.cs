using System;
using Runtime.Data;

namespace Runtime.DTO
{
    [Serializable]
    public class OpenMeteoWeatherDTO : IConvertableToWeather
    {
        public CurrentInfo current;

        [Serializable]
        public class CurrentInfo
        {
            public decimal temperature_2m;
            public decimal relative_humidity_2m;
            public decimal apparent_temperature;
            public decimal rain;
            public decimal cloud_cover;
            public decimal snowfall;
            public decimal wind_speed_10m;
            public decimal wind_direction_10m;
            public decimal wind_gusts_10m;
        }

        public Weather Convert() => 
            new(current.temperature_2m, current.relative_humidity_2m, current.apparent_temperature, current.rain, current.cloud_cover, current.snowfall, current.wind_speed_10m, current.wind_direction_10m, current.wind_gusts_10m);
    }
}