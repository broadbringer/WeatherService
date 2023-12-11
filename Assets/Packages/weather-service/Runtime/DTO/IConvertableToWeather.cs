using WeatherService.Runtime.Data;
using WeatherService.Runtime.Enums;

namespace WeatherService.Runtime.DTO
{
    public interface IConvertableToWeather
    {
        WeatherData ConvertToWeather(WindMeasurementUnit windMeasurementUnit, TemperatureMeasurementUnit temperatureMeasurementUnit);
    }
}