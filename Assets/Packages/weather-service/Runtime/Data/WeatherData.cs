﻿namespace WeatherService.Runtime.Data
{
    public class WeatherData
    {
        public decimal Temperature;
        public decimal Humidity;
        public decimal ApparentTemperature;
        public decimal Rain;
        public decimal Cloud;
        public decimal Snowfall;
        public WindData WindData;

        private WindMeasurementUnit _windMeasurementUnit;
        private TemperatureMeasurementUnit _temperatureMeasurementUnit;
        
        public WeatherData(decimal temperature, decimal humidity, decimal apparentTemperature, decimal rain,
            decimal cloud, decimal snowfall, decimal windSpeed, decimal windDirection, decimal windGust, WindMeasurementUnit givenWindMeasurementUnit, TemperatureMeasurementUnit defaultWindMeasurementUnit)
        {
            Temperature = temperature;
            Humidity = humidity;
            ApparentTemperature = apparentTemperature;
            Rain = rain;
            Cloud = cloud;
            Snowfall = snowfall;
            WindData = new WindData(windSpeed, windDirection, windGust, givenWindMeasurementUnit);
        }

        public WindData GetWindDataIn(WindMeasurementUnit windMeasurementUnit) => 
            WindData.GetIn(windMeasurementUnit);
    }
}