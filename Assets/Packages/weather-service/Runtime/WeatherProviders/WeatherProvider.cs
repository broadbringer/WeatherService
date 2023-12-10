using System.Threading;
using Cysharp.Threading.Tasks;
using WeatherService.Runtime.Data;
using WeatherService.Runtime.DTO;
using WeatherService.Runtime.Network.GetWeatherRequests;
using WeatherService.Runtime.Utils;

namespace WeatherService.Runtime.Network.Interfaces
{
    public abstract class WeatherProvider<T, U> : IWeatherProvider where T : WeatherRequest, new() where U : IConvertableToWeather
    {
        private readonly T _getWeatherRequest = new T();
        
        protected abstract WindMeasurementUnit _windMeasurementUnit { get; }
        protected abstract TemperatureMeasurementUnit _temperatureMeasurementUnit { get; }
        
        public async UniTask<WeatherData> GetWeather(float latitude, float longitude, CancellationTokenSource cancellationTokenSource, WindMeasurementUnit defaultWindMeasurementUnit, TemperatureMeasurementUnit defaultTemperatureMeasurementUnit) =>
            (await _getWeatherRequest.GetJson(latitude, longitude, cancellationTokenSource)).Deserialize<U>().ConvertToWeather(_windMeasurementUnit, _temperatureMeasurementUnit);
    }
}