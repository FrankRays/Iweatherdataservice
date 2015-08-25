using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Xml.Linq;

namespace Iweather
{
    public class WeatherDataProviderWorldWeatherOnline : IWeatherDataService
    {
        //sigleton instance for WorldWeatherOnline site
        private static WeatherDataProviderWorldWeatherOnline instance;

        //constractor for WorldWeatherOnline site
        private WeatherDataProviderWorldWeatherOnline() { }

        //singelton implementation for WorldWeatherOnline site
        public static WeatherDataProviderWorldWeatherOnline Instance
        {
            get
            {
                if(instance == null)
                {
                    instance = new WeatherDataProviderWorldWeatherOnline();
                }
                return instance;
            }
        }

        //a developer key that needed for using WorldWeatherOnline API
        private string Key = "88c072405828f5adb8af3125a76e6";

        //address to the site and building weatherdata sturcture
        public WeatherData GetWeatherData(Location location)
        {
            XDocument xdoc=null;
            WeatherData WD=new WeatherData();
            string addr="";

            try
            {
                if (location.countryName == null || location.cityName == null)
                {
                    throw (new WeatherDataServiceException("WeatherDataServiceException : location.countryName or location.countryName are null"));
                }

                //sending a correct sturcure of query string to the site
                addr = "http://api.worldweatheronline.com/free/v2/weather.ashx?key=" + Key + "&q=" + location.cityName + ","+ location.countryName + "&format=xml";
                xdoc = XDocument.Load(addr);
            }

            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            try
            {
                //parsing the XML recieved from the site by its unique stucture
                var list = from item in xdoc.Descendants("data")
                select new
                {
                    Name = item.Element("request").Element("query").Value,
                    Temp = item.Element("current_condition").Element("temp_C").Value,
                    Pressure = item.Element("current_condition").Element("pressure").Value,
                    Humidity = item.Element("current_condition").Element("humidity").Value,
                    WindSpeed = item.Element("current_condition").Element("windspeedKmph").Value,
                    WindDirection = item.Element("current_condition").Element("winddir16Point").Value
                };
                foreach (var item in list)
                {
                    //building the weatherdata structure
                    WD.cityName = item.Name;
                    WD.temp = double.Parse(item.Temp);
                    WD.pressure = int.Parse(item.Pressure);
                    WD.humidity = item.Humidity + "%";
                    WD.windSpeed = double.Parse(item.WindSpeed);
                    WD.windDirection = item.WindDirection;
                }
            }

            catch (Exception e)
            {
                Console.WriteLine(e.Message + " : caused from internet problem or wrong values in the Location");
            }

            return WD;
        }

    }
}
