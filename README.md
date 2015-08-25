Welcome to Shai & Maor's Iweatherdataservice


SUMMARY :

	this is a final project of C# course at shenkar college

	please take a look at the GitPages of our project

	http://maortoubian.github.io/

API - HOW TO US :

    //example of use , sample code of how to implement the factory and the interface


        //declaring and assiging Location object
        Location loc = new Location();
        loc.cityName = "London";
        loc.countryName = "UK";


        //requesting the WUNDERGROUND provider using the provider identifier in the factory
		//you can use 1 of the 3 providers options : WUNDERGROUND / WORLDWEATHERONLINE / OPENMAP	
        IWeatherDataService service = WeatherDataServiceFactory.getWeatherDataService(WeatherDataServiceFactory.Providers.WUNDERGROUND);

        //recieving a WeatherData object from the first provider
        WeatherData weatherData = service.GetWeatherData(loc);

        //printing the WeatherData fields, OUTPUT Example :
        //WUNDERGROUND: city: London, temp: 14 celsius, humidity: 94 %, pressure: 1004 hPa, wind: 20 kPh West
        System.Console.WriteLine("WUNDERGROUND : city : " + weatherData.cityName +
                                      ", temp : " + weatherData.temp + " celsius" +
                                      ", humidity : " + weatherData.humidity +
                                      ", pressure : " + weatherData.pressure + " hPa" +
                                      ", wind : " + weatherData.windSpeed + " kPh" +
                                      " " + weatherData.windDirection);
					  
		enjoy

CONTACT US :

	we will be happy to hear what you think about the project and answer to any question about it

	Maor Toubian : MAORTOUBIAN@GMAIL.COM

	Shai Malka : SHAI2210@GMAIL.COM
