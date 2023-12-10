using WeatherService.Runtime.Data;

namespace WeatherService.Runtime.DTO
{
    public interface IConvertableToWeather
    {
        WeatherData ConvertToWeather(WindMeasurementUnit windMeasurementUnit, TemperatureMeasurementUnit temperatureMeasurementUnit);
    }
}