using System;
using System.Collections.Generic;
using System.Linq;
using WeatherService.Runtime.Data;
using WeatherService.Runtime.Network.Interfaces;
using Random = UnityEngine.Random;

namespace WeatherService.Runtime
{
    public class Weather
    {
        public Dictionary<IWeatherProvider, WeatherData> WeatherProviderToWeatherDataMap { get; } = new();

        public void Add(WeatherData data, IWeatherProvider forProvider) =>
            WeatherProviderToWeatherDataMap[forProvider] = data;

        public void Clear() =>
            WeatherProviderToWeatherDataMap.Clear();


        public decimal GetValueFor(WeatherType weatherType, WindMeasurementUnit withWindUnit,
            TemperatureMeasurementUnit withTemperatureMeasurementUnit)
        {
            if (WeatherProviderToWeatherDataMap.Count > 0)
                return GetAverageValueFromEachProvider(weatherType, withWindUnit, withTemperatureMeasurementUnit);

            throw new Exception("You don't have any ready weather data's");
        }

        public decimal GetValueFor<T>(WeatherType weatherType, WindMeasurementUnit withWindUnit,
            TemperatureMeasurementUnit withTemperatureMeasurementUnit, T preferredProvider) where T : IWeatherProvider
        {
            var data = TryGetValue(preferredProvider);
            if (data != null)
            {
                return GetValueFromPreferredProvider(data, weatherType, withWindUnit, withTemperatureMeasurementUnit);
            }

            throw new Exception("You don't have any ready weather data's");
        }

        private decimal GetValueFromPreferredProvider(WeatherData weatherData, WeatherType weatherType,
            WindMeasurementUnit withWindUnit,
            TemperatureMeasurementUnit withTemperatureMeasurementUnit)
        {
            return weatherType switch
            {
                WeatherType.Temperature => weatherData.Temperature,
                WeatherType.Humidity => weatherData.Humidity,
                WeatherType.ApparentTemperature => weatherData.ApparentTemperature,
                WeatherType.Rain => weatherData.Rain,
                WeatherType.Cloud => weatherData.Cloud,
                WeatherType.Snowfall => weatherData.Snowfall,
                WeatherType.WindSpeed => weatherData.GetWindDataIn(withWindUnit).WindSpeed,
                WeatherType.WindDirection => weatherData.GetWindDataIn(withWindUnit).WindDirection,
                WeatherType.WindGust => weatherData.GetWindDataIn(withWindUnit).WindGust,
                _ => throw new Exception($"There are no such weatherType {weatherType}")
            };
        }

        private decimal GetAverageValueFromEachProvider(WeatherType weatherType, WindMeasurementUnit withWindUnit,
            TemperatureMeasurementUnit withTemperatureMeasurementUnit)
        {
            return weatherType switch
            {
                WeatherType.Temperature => WeatherProviderToWeatherDataMap.Values.Average(v => v.Temperature),
                WeatherType.Humidity => WeatherProviderToWeatherDataMap.Values.Average(v => v.Humidity),
                WeatherType.ApparentTemperature => WeatherProviderToWeatherDataMap.Values.Average(v =>
                    v.ApparentTemperature),
                WeatherType.Rain => WeatherProviderToWeatherDataMap.Values.Average(v => v.Rain),
                WeatherType.Cloud => WeatherProviderToWeatherDataMap.Values.Average(v => v.Cloud),
                WeatherType.Snowfall => WeatherProviderToWeatherDataMap.Values.Average(v => v.Snowfall),
                WeatherType.WindSpeed => WeatherProviderToWeatherDataMap.Values.Average(v =>
                    v.GetWindDataIn(withWindUnit).WindSpeed),
                WeatherType.WindDirection => WeatherProviderToWeatherDataMap.Values.Average(v =>
                    v.GetWindDataIn(withWindUnit).WindDirection),
                WeatherType.WindGust => WeatherProviderToWeatherDataMap.Values.Average(v =>
                    v.GetWindDataIn(withWindUnit).WindGust),
                _ => throw new Exception($"There are no such weatherType {weatherType}")
            };
        }

        private WeatherData TryGetValue(IWeatherProvider fromProvider)
        {
            if (!WeatherProviderToWeatherDataMap.TryGetValue(fromProvider, out var data))
                throw new Exception($"There are no such weather provider as {fromProvider.GetType()}");

            return data;
        }
    }
}