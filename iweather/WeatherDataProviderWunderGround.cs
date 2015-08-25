using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Xml.Linq;

namespace Iweather
{
    public class WeatherDataProviderWunderGround : IWeatherDataService
    {
        //sigleton instance for WunderGround site
        private static WeatherDataProviderWunderGround instance;

        //constractor for WunderGround site
        private WeatherDataProviderWunderGround() { }

        //singelton implementation for WunderGround site
        public static WeatherDataProviderWunderGround Instance
        {
            get
            {
                if(instance == null)
                {
                    instance = new WeatherDataProviderWunderGround();
                }
                return instance;
            }
        }

        //a developer key that needed for using WunderGround API
        private string Key = "3ec60447f2e43912";

        //address to the site and building weatherdata sturcture
        public WeatherData GetWeatherData(Location location)
        {
            XDocument xdoc=null;
            WeatherData WD=new WeatherData();
            string addr="";

            try
            {
                if ( location.countryName == null || location.cityName == null)
                {
                    throw (new WeatherDataServiceException("WeatherDataServiceException : location.countryName or location.countryName are null"));
                }

                //sending a correct sturcure of query string to the site
                addr = "http://api.wunderground.com/api/" + Key + "/conditions/q/" + location.countryName + "/" + location.cityName + ".xml";

                xdoc = XDocument.Load(addr);

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        
            try
            {    
                //parsing the XML recieved from the site by its unique stucture
                var list = from item in xdoc.Descendants("response")
                select new 
                {
                    
                    Name = item.Element("current_observation").Element("display_location").Element("city").Value,
                    Temp = item.Element("current_observation").Element("temp_c").Value,
                    Pressure = item.Element("current_observation").Element("pressure_mb").Value,
                    Humidity = item.Element("current_observation").Element("relative_humidity").Value,
                    WindSpeed = item.Element("current_observation").Element("wind_kph").Value,
                    WindDirection = item.Element("current_observation").Element("wind_dir").Value

                };
                foreach (var item in list)
                {
                    //building the weatherdata structure
                    WD.cityName = item.Name;
                    WD.temp = double.Parse(item.Temp);
                    WD.pressure = int.Parse(item.Pressure);
                    WD.humidity = item.Humidity;
                    WD.windSpeed = double.Parse(item.WindSpeed);
                    WD.windDirection = item.WindDirection;

                }
            }

            catch (Exception e)
            {
                Console.WriteLine(e.Message + " : caused from parsing error or wrong values in the Location");
            }

            return WD;
        }

    }
}
