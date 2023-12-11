using System.Threading;
using Cysharp.Threading.Tasks;
using UnityEngine;
using WeatherService.Runtime.Enums;
using WeatherService.Runtime.WeatherProviders;

namespace Samples
{
    public class ExampleOfWorkingWithService : MonoBehaviour
    {
        private void Start() => 
            GetWeather();

        private async UniTask GetWeather()
        {
            var service = new WeatherService.Runtime.WeatherService();
            var cancellationTokenSource = new CancellationTokenSource();
            var cancellationTokenSourceTwo = new CancellationTokenSource();
            service.Register(new OpenMeteoWeatherProvider());
            service.Register(new OpenWeatherWeatherProvider());

            var weather = (await service.GetWeather(33.33f, 33.33f, cancellationTokenSource)).GetValueFor<OpenMeteoWeatherProvider>(WeatherType.Temperature, WindMeasurementUnit.KilometerPerHour, TemperatureMeasurementUnit.Celsius);
            var weatherTwo = (await service.GetWeather(33.33f, 33.33f, cancellationTokenSourceTwo)).GetValueFor<OpenWeatherWeatherProvider>(WeatherType.Temperature, WindMeasurementUnit.KilometerPerHour, TemperatureMeasurementUnit.Celsius);
            Debug.Log(weather);
            Debug.Log(weatherTwo);
        }
      
    }
}
