using WeatherService.Runtime.Data;

namespace WeatherService.Runtime.DTO
{
    public interface IConvertableToWeather
    {
        Weather Convert();
    }
}