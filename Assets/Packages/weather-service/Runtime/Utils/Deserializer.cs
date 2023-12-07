using Unity.Plastic.Newtonsoft.Json;
using WeatherService.Runtime.DTO;

namespace WeatherService.Runtime.Utils
{
    public static class Deserializer
    {
        public static T Deserialize<T>(this string json) =>
            JsonConvert.DeserializeObject<T>(json, new JsonSerializerSettings
            {
                FloatParseHandling = FloatParseHandling.Decimal
            });
    }
}