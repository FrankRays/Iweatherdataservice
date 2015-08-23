Welcome to Shai & Maor's Iweatherdataservice

SUMMARY :

	this is a final project of C# course at shenkar college

	please take a look at the GitHub repository of the project

	https://github.com/maortoubian/Iweatherdataservice

API - HOW TO US :

	//declaring and assiging Location object
	Location loc = new Location();

	loc.cityName = "London";

	loc.countryName = "UK";

	//requesting the 1st provider using the provider identifier in the factory
	IWeatherDataService service = WeatherDataServiceFactory .getWeatherDataService(WeatherDataServiceFactory.Providers.WUNDERGROUND);

	//recieving a WeatherData object from the first provider
	WeatherData weatherData = service.GetWeatherData(loc);

	//printing the WeatherData fields, OUTPUT Example : WUNDERGROUND : London, 24 celsius
	System.Console.WriteLine("WUNDERGROUND : " + weatherData.cityName + ", " + weatherData.temp + " celsius");

	enjoy

CONTACT US :

	we will be happy to hear what you think about the project and answer to any question about it

	Maor Toubian : MAORTOUBIAN@GMAIL.COM

	Shai Malka : SHAI2210@GMAIL.COM 