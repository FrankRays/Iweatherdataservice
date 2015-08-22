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
                //sending a correct sturcure of query string to the site
                addr = "http://api.wunderground.com/api/" + Key + "/forecast/geolookup/q/" + location.countryName + "/" + location.cityName + ".xml";
                xdoc = XDocument.Load(addr);

            }

            catch (Exception e)
            {
              throw (new  WeatherDataServiceException("web problem")); 
            }

            try
            {    
                //parsing the XML recieved from the site by its unique stucture
                var list = from item in xdoc.Descendants("response")
                select new
                {

                    Temp = item.Element("forecast").Element("simpleforecast").Element("forecastdays").Element("forecastday").Element("high").Element("celsius").Value,
                    Name = item.Element("location").Element("city").Value

                };
                foreach (var item in list)
                {              
                    //building the weatherdata structure
                    WD.cityName = item.Name;
                    WD.temp = double.Parse(item.Temp);

                }
            }

            catch (Exception e)
            {
                throw (new WeatherDataServiceException("persing error"));
            }
            return WD;
        }

    }
}
