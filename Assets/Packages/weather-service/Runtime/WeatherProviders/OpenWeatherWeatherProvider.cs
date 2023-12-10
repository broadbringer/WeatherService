using WeatherService.Runtime.DTO;
using WeatherService.Runtime.Network.GetWeatherRequests;

namespace WeatherService.Runtime.Network.Interfaces
{
    public class OpenWeatherWeatherProvider : WeatherProvider<WeatherFromOpenWeatherRequest, OpenWeatherDTO>
    {
        
    }
}