using Runtime.Data;

namespace Runtime.DTO
{
    public interface IConvertableToWeather
    {
        Weather Convert();
    }
}