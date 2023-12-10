using WeatherService.Runtime.Data;
using WeatherService.Runtime.DTO;
using WeatherService.Runtime.Network.GetWeatherRequests;

namespace WeatherService.Runtime.Network.Interfaces
{
    public class OpenMeteoWeatherProvider : WeatherProvider<WeatherFromOpenMeteoRequest, OpenMeteoWeatherDTO>
    {
        protected override WindMeasurementUnit _windMeasurementUnit => WindMeasurementUnit.KilometerPerHour;
        protected override TemperatureMeasurementUnit _temperatureMeasurementUnit => TemperatureMeasurementUnit.Celsius;
    }
}