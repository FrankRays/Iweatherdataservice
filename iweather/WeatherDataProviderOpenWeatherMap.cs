using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Xml.Linq;

namespace Iweather
{
    public class WeatherDataProviderOpenWeatherMap : IWeatherDataService
    {
        //sigleton instace for OpenWeatherMap site
        private static WeatherDataProviderOpenWeatherMap instance;

        //constractor for OpenWeatherMap site
        private WeatherDataProviderOpenWeatherMap() { }

        //singelton implementation for OpenWeatherMap site
        public static WeatherDataProviderOpenWeatherMap Instance
        {
            get
            {
                if(instance == null)
                {
                    instance = new WeatherDataProviderOpenWeatherMap();
                }
                return instance;
            }   
        }

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
                addr = "http://api.openweathermap.org/data/2.5/weather?q=" + location.cityName + "," + location.countryName + "&mode=xml";
                xdoc = XDocument.Load(addr);
            }

            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            try
            {
                //parsing the XML recieved from the site by its unique stucture
                var list = from item in xdoc.Descendants("current")
                select new
                {
                    Name = item.Element("city").Attribute("name").Value,
                    Temp = item.Element("temperature").Attribute("value").Value,
                    Pressure = item.Element("pressure").Attribute("value").Value,
                    Humidity = item.Element("humidity").Attribute("value").Value,
                    WindSpeed = item.Element("wind").Element("speed").Attribute("value").Value,
                    WindDirection = item.Element("wind").Element("direction").Attribute("code").Value
                };
                foreach (var item in list)
                {
                    //building the weatherdata structure
                    WD.cityName = item.Name;
                    WD.temp = FarToCell(double.Parse(item.Temp));
                    WD.pressure = int.Parse(item.Pressure);
                    WD.humidity = item.Humidity + "%";
                    WD.windSpeed = double.Parse(item.WindSpeed) * 3.6; //convert from mps to kph
                    WD.windDirection = item.WindDirection;
                }
                
            }

            catch (Exception e)
            {
                Console.WriteLine(e.Message + " : caused from internet problem or wrong values in the Location");
            }

            return WD;
        }

        //function that convert from kelvin to celcius
        public double FarToCell(double f)
        {
            double c = f-273.15;
            return c;
        }

    }
}
