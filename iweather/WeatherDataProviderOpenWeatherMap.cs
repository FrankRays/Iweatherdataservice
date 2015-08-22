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
                //sending a correct sturcure of query string to the site
                addr = "http://api.openweathermap.org/data/2.5/weather?q=" + location.cityName + "," + location.countryName + "&mode=xml";
                xdoc = XDocument.Load(addr);
            }

            catch (Exception e)
            {
              throw (new  WeatherDataServiceException("web problem")); 
            }

            try
            {
                //parsing the XML recieved from the site by its unique stucture
                var list = from item in xdoc.Descendants("current")
                select new
                {
                    Name = item.Element("city").Attribute("name").Value,
                    Temp = item.Element("temperature").Attribute("value").Value

            };
                foreach (var item in list)
                {
                    //building the weatherdata structure
                    WD.cityName = item.Name;
                    WD.temp = FarToCell(double.Parse(item.Temp));
                }
                
            }

            catch (Exception e)
            {
                throw (new WeatherDataServiceException("persing error"));
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
