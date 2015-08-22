Welcome to Shai & Maor's Iweatherdataservice

SUMMARY :

this is a final project of C# course at shenkar college

API - HOW TO US :

1. declare a Location object for sending to the wanted provider :

	Location loc = new Location();
	loc.cityName = "London";
	loc.countryName = "UK";

2. call the wanted provider from the factory with one of the providers enum values :

	WeatherDataServiceFactory.Providers.WUNDERGROUND

	WeatherDataServiceFactory.Providers.OPENMAP

	WeatherDataServiceFactory.Providers.WORLDWEATHERONLINE

	and asign it to a WeatherData var

	FOR EXAMPLE:

	WeatherData WUNDERGROUND = WeatherDataServiceFactory.getWeatherDataService(WeatherDataServiceFactory.Providers.WUNDERGROUND, loc);

3. what you will get is a WeatherData object that holds the wanted city and its current temperature :

	System.Console.WriteLine("WUNDERGROUND : " + WUNDERGROUND.cityName + " " + WUNDERGROUND.temp);

	the output will be : WUNDERGROUND : London 28

	enjoy

CONTACT US :

we will be happy to hear what you think about the project and answer to any question about it

Maor Toubian : MAORTOUBIAN@GMAIL.COM

Shai Malka   : SHAI2210@GMAIL.COM 