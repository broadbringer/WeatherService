using Cysharp.Threading.Tasks;

namespace WeatherService.Runtime.Network.Interfaces
{
    public interface IWeatherProvider
    {
        string BaseURL { get; }
        
        string GetJson();
        UniTask<string> GetJson(float latitude, float longitude);
    }
}