namespace Packages.weather_service.Runtime.Data
{
    public class Weather
    {
        public decimal Temperature;
        public decimal Humidity;
        public decimal ApparentTemperature;
        public decimal Rain;
        public decimal Showers;
        public decimal Snowfall;
        public decimal WindSpeed;
        public decimal WindDirection;
        public decimal WindGust;

        public Weather(decimal temperature, decimal humidity, decimal apparentTemperature, decimal rain,
            decimal showers, decimal snowfall, decimal windSpeed, decimal windDirection, decimal windGust)
        {
            Temperature = temperature;
            Humidity = humidity;
            ApparentTemperature = apparentTemperature;
            Rain = rain;
            Showers = showers;
            Snowfall = snowfall;
            WindSpeed = windSpeed;
            WindDirection = windDirection;
            WindGust = windGust;
        }
    }
    
    public enum TimeOfDay
    {
        Day,
        Night
    }
}