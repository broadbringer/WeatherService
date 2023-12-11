using System.Globalization;

namespace WeatherService.Runtime.Network.GetWeatherRequests
{
    public class WeatherFromOpenMeteoRequest : WeatherRequest
    {
        protected override string BaseURL =>
            "https://api.open-meteo.com/v1/forecast?";

        protected override string SetRequestParams(float latitude, float longitude) =>
            $"latitude={latitude.ToString(CultureInfo.InvariantCulture)}&longitude={longitude.ToString(CultureInfo.InvariantCulture)}&current=temperature_2m,relative_humidity_2m,apparent_temperature,rain,snowfall,cloud_cover,wind_speed_10m,wind_direction_10m,wind_gusts_10m";
    }
}