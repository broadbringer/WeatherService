using System;
using System.Collections.Generic;

namespace WeatherService.Runtime.Data
{
    public class WindData
    {
        public decimal WindSpeed;
        public decimal WindDirection;
        public decimal WindGust;

        private WindMeasurementUnit _measurementUnit;

        private static readonly Dictionary<Tuple<WindMeasurementUnit, WindMeasurementUnit>, decimal> ConversionFactors =
            new()
            {
                { Tuple.Create(WindMeasurementUnit.MeterPerSecond, WindMeasurementUnit.KilometerPerHour), 3.6m },
                { Tuple.Create(WindMeasurementUnit.MeterPerSecond, WindMeasurementUnit.MilesPerHour), 2.23694m },
                { Tuple.Create(WindMeasurementUnit.KilometerPerHour, WindMeasurementUnit.MeterPerSecond), 1m / 3.6m },
                { Tuple.Create(WindMeasurementUnit.KilometerPerHour, WindMeasurementUnit.MilesPerHour), 0.621371m },
                { Tuple.Create(WindMeasurementUnit.MilesPerHour, WindMeasurementUnit.MeterPerSecond), 1m / 2.23694m },
                { Tuple.Create(WindMeasurementUnit.MilesPerHour, WindMeasurementUnit.KilometerPerHour), 1.60934m }
            };

        public WindData(decimal windSpeed, decimal windDirection, decimal windGust,
            WindMeasurementUnit givenWindMeasurementUnit)
        {
            WindSpeed = windSpeed;
            WindDirection = windDirection;
            WindGust = windGust;
            _measurementUnit = givenWindMeasurementUnit;
        }
        
        public WindData GetIn(WindMeasurementUnit windMeasurementUnit)
        {
            if (_measurementUnit == windMeasurementUnit)
                return this;

            if (!ConversionFactors.TryGetValue(Tuple.Create(_measurementUnit, windMeasurementUnit),
                    out decimal conversionFactor))
                throw new InvalidOperationException("Conversion between specified units is not supported.");

            WindSpeed *= conversionFactor;
            WindDirection *= conversionFactor;
            WindGust *= conversionFactor;

            _measurementUnit = windMeasurementUnit;

            return this;
        }
    }
}