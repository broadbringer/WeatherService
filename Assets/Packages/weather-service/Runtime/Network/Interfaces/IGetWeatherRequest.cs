using Cysharp.Threading.Tasks;

namespace Packages.weather_service.Runtime.Network.Interfaces
{
    public interface IGetWeatherRequest
    {
        string BaseURL { get; }
        
        string GetJson();
        UniTask<string> GetJson(float latitude, float longitude);
    }
}