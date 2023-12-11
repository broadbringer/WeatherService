using System;
using System.Collections.Generic;

namespace WeatherService.Runtime.Data
{
    public class TemperatureData
    {
        public decimal Temperature;

        private TemperatureMeasurementUnit _temperatureMeasurementUnit;

        public TemperatureData(decimal temperature, TemperatureMeasurementUnit temperatureMeasurementUnit)
        {
            Temperature = temperature;
            _temperatureMeasurementUnit = temperatureMeasurementUnit;
        }

        private decimal ConvertTemperature(decimal temperature, TemperatureMeasurementUnit fromUnit, TemperatureMeasurementUnit toUnit)
        {
            if (fromUnit == toUnit)
                return temperature;

            decimal temperatureInCelsius = fromUnit switch
            {
                TemperatureMeasurementUnit.Kelvin => temperature - 273.15M,
                TemperatureMeasurementUnit.Fahrenheit => (temperature - 32) * 5 / 9,
                TemperatureMeasurementUnit.Celsius => temperature,
                _ => throw new ArgumentException("Invalid temperature measurement unit"),
            };

            return toUnit switch
            {
                TemperatureMeasurementUnit.Kelvin => temperatureInCelsius + 273.15M,
                TemperatureMeasurementUnit.Celsius => temperatureInCelsius,
                TemperatureMeasurementUnit.Fahrenheit => temperatureInCelsius * 9 / 5 + 32,
                _ => throw new ArgumentException("Invalid temperature measurement unit"),
            };
        }

        public TemperatureData GetIn(TemperatureMeasurementUnit temperatureMeasurementUnit)
        {
            if (_temperatureMeasurementUnit == temperatureMeasurementUnit)
                return this;

            Temperature = ConvertTemperature(Temperature,_temperatureMeasurementUnit, temperatureMeasurementUnit);

            return this;
        }
    }
}