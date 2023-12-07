using Cysharp.Threading.Tasks;
using Unity.Plastic.Newtonsoft.Json;
using WeatherService.Runtime.Data;
using WeatherService.Runtime.DTO;
using WeatherService.Runtime.Network.GetWeatherRequests;

namespace WeatherService.Runtime.Network.Interfaces
{
    public class OpenWeatherProvider : IWeatherProvider
    {
        private readonly GetWeatherRequest _getWeatherRequest = new GetWeatherFromOpenWeatherProvider();
        private IConvertableToWeather weatherDTO = new OpenWeatherDTO();

        public async UniTask<Weather> GetWeather(float latitude, float longitude)
        {
            var weatherJson = await _getWeatherRequest.GetJson(latitude, longitude);
            weatherDTO = JsonConvert.DeserializeObject<OpenWeatherDTO>(weatherJson, new JsonSerializerSettings
            {
                FloatParseHandling = FloatParseHandling.Decimal
            });

            return weatherDTO.ConvertToWeather();
        }
    }
}