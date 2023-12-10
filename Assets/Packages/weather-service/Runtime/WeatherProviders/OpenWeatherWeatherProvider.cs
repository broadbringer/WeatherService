using WeatherService.Runtime.Data;
using WeatherService.Runtime.DTO;
using WeatherService.Runtime.Network.GetWeatherRequests;

namespace WeatherService.Runtime.Network.Interfaces
{
    public class OpenWeatherWeatherProvider : WeatherProvider<WeatherFromOpenWeatherRequest, OpenWeatherDTO>
    {
        protected override WindMeasurementUnit _windMeasurementUnit => WindMeasurementUnit.MeterPerSecond;
        protected override TemperatureMeasurementUnit _temperatureMeasurementUnit => TemperatureMeasurementUnit.Kelvin;
    }
}