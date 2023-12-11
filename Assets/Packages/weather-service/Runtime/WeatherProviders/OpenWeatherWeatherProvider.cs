using WeatherService.Runtime.DTO;
using WeatherService.Runtime.Enums;
using WeatherService.Runtime.Network.GetWeatherRequests;

namespace WeatherService.Runtime.WeatherProviders
{
    public class OpenWeatherWeatherProvider : WeatherProvider<WeatherFromOpenWeatherRequest, OpenWeatherDTO>
    {
        protected override WindMeasurementUnit _windMeasurementUnit => WindMeasurementUnit.MeterPerSecond;
        protected override TemperatureMeasurementUnit _temperatureMeasurementUnit => TemperatureMeasurementUnit.Kelvin;
    }
}