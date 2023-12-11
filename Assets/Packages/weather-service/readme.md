This Weather Service was made for give you opportunity to take a weather from any weather provider you want.

Installation.
You can Install it by github link : https://github.com/broadbringer/WeatherService.git?path=Assets/Packages/weather-service

Important : Weather Service has dependency on Unitask Package.
For working service you should add to you manifest.json 
"scopedRegistries": [
    {
      "name": "package.openupm.com",
      "url": "https://package.openupm.com",
      "scopes": [
        "com.cysharp.unitask"
      ]
    }
  ]

  Without it you cannot add package to your project.

  API Example 

  You should create where you want WeatherService and register in it IWeatherProvider.
  You have 2 default realization such as :
  OpenMeteoWeatherProvider
  and
  OpenWeatherWeatherProvider

  WeatherService Have one API method called GetWeather and return Weather object which have API GetValueFor,
  where you can set from wich provider you want to take wheather if not - it will return average value from all providers.
  Also you can set which WeatherType do you want to take, Temperature, Rain etc and set MeasurementUnit.

  As Example
   var weather = (await service.GetWeather(33.33f, 33.33f, cancellationTokenSource)).GetValueFor<OpenMeteoWeatherProvider>(WeatherType.Temperature, WindMeasurementUnit.KilometerPerHour, TemperatureMeasurementUnit.Celsius); 

   In here i want to get current temperature from OpenMeteoWeatherProvider, and want to get it value in Celsius.

   Enjoy using it!