using System;
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
                public decimal temp;
                public decimal humidity;
                public decimal feels_like;
            }

            [System.Serializable]
            public class WindInfo
            {
                public decimal speed;
                public decimal deg;
                public decimal gust;
            }

            [System.Serializable]
            public class RainInfo
            {
                public decimal _1h;
            }

            [Serializable]
            public class CloudInfo
            {
                public decimal all;
            }

            [Serializable]
            public class SnowInfo
            {
                public decimal _1h;
            }


            public Weather ConvertToWeather()
            {
                var rainInfo = rain ?? new RainInfo();
                var windInfo = wind ?? new WindInfo();
                var snowInfo = snow ?? new SnowInfo();
                var cloudInfo = clouds ?? new CloudInfo();
                
               return new Weather (main.temp, main.humidity, main.feels_like, rainInfo._1h, cloudInfo.all, snowInfo._1h, windInfo.speed,
                    windInfo.deg, windInfo.gust);
            }
            
    }
}