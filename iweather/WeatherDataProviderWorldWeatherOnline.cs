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
                //sending a correct sturcure of query string to the site
                addr = "http://api.worldweatheronline.com/free/v2/weather.ashx?key=" + Key + "&q=" + location.cityName + ","+ location.countryName + "&format=xml";
                xdoc = XDocument.Load(addr);

            }

            catch (Exception e)
            {
              throw (new  WeatherDataServiceException("web problem")); 
            }

            try
            {
                //parsing the XML recieved from the site by its unique stucture
                var list = from item in xdoc.Descendants("data")
                select new
                {

                    Temp = item.Element("current_condition").Element("temp_C").Value,
                    Name = item.Element("request").Element("query").Value

                };
                foreach (var item in list)
                {
                    //printing to console for presentation only
                    System.Console.WriteLine("WorldWeatherOnline : " + item.Name + " " + item.Temp);
                   
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
