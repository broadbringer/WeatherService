using System.Threading;
using Cysharp.Threading.Tasks;
using WeatherService.Runtime.Data;

namespace WeatherService.Runtime.Network.Interfaces
{
    public interface IWeatherProvider
    {
        UniTask<WeatherData> GetWeather(float latitude, float longitude, CancellationTokenSource cancellationTokenSource,WindMeasurementUnit windMeasurementUnit, TemperatureMeasurementUnit temperatureMeasurementUnit);
    }
}