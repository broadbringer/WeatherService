using System.Threading;
using Cysharp.Threading.Tasks;
using WeatherService.Runtime.Data;
using WeatherService.Runtime.Enums;

namespace WeatherService.Runtime.WeatherProviders
{
    public interface IWeatherProvider
    {
        UniTask<WeatherData> GetWeather(float latitude, float longitude, CancellationTokenSource cancellationTokenSource,WindMeasurementUnit windMeasurementUnit, TemperatureMeasurementUnit temperatureMeasurementUnit);
    }
}