using Packages.weather_service.Runtime.Data;

namespace Packages.weather_service.Runtime.DTO
{
    public interface IConvertableToWeather
    {
        Weather Convert();
    }
}