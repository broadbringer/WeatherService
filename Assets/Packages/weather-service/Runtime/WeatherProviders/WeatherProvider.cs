using Cysharp.Threading.Tasks;
using WeatherService.Runtime.Data;
using WeatherService.Runtime.DTO;
using WeatherService.Runtime.Network.GetWeatherRequests;
using WeatherService.Runtime.Utils;

namespace WeatherService.Runtime.Network.Interfaces
{
    public class WeatherProvider<T, U> : IWeatherProvider where T : GetWeatherRequest, new() where U : IConvertableToWeather
    {
        private readonly T _getWeatherRequest = new T();

        public async UniTask<Weather> GetWeather(float latitude, float longitude) =>
            (await _getWeatherRequest.GetJson(latitude, longitude)).Deserialize<U>().ConvertToWeather();
    }
}