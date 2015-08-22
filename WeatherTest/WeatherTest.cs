using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Iweather;

namespace WeatherTest
{
    [TestClass]
    public class WeatherTest
    {

        //Test for checking if the convertion from kelvin to celsius are correct for OpenWeatherMap site
        [TestMethod]
        public void TempConver()
        {
            double kelvin = 300;
            double celsius = 26.85;

            WeatherDataProviderOpenWeatherMap WD = WeatherDataProviderOpenWeatherMap.Instance;

            double actual = Math.Round(WD.FarToCell(kelvin),2);
            Assert.AreEqual(celsius, actual);
        }

        //Test for checking if the funtion getWeatherData to OpenWeatherMap site are working proparly
        [TestMethod]
        public void OpenWeatherMapTest()
        {
            Location loc = new Location();
            WeatherData WDCheck = null;

            string actualCity = "London";

            loc.cityName = "london";
            loc.countryName = "UK";

            WeatherDataProviderOpenWeatherMap WD = WeatherDataProviderOpenWeatherMap.Instance;

            WDCheck = WD.GetWeatherData(loc);

            Assert.AreEqual(WDCheck.cityName, actualCity);
        }

        //Test for checking if the funtion getWeatherData to WorldWeatherOnline site are working proparly
        [TestMethod]
        public void WorldWeatherOnlineTest()
        {
            Location loc = new Location();
            WeatherData WDCheck = null;

            string actualCity = "London, United Kingdom";

            loc.cityName = "london";
            loc.countryName = "UK";

            WeatherDataProviderWorldWeatherOnline WD = WeatherDataProviderWorldWeatherOnline.Instance;

            WDCheck = WD.GetWeatherData(loc);

            Assert.AreEqual(WDCheck.cityName, actualCity);
        }

        //Test for checking if the funtion getWeatherData to WunderGround site are working proparly
        [TestMethod]
        public void WunderGroundTest()
        {
            Location loc = new Location();
            WeatherData WDCheck = null;

            string actualCity = "London";

            loc.cityName = "london";
            loc.countryName = "UK";

            WeatherDataProviderWunderGround WD = WeatherDataProviderWunderGround.Instance;

            WDCheck = WD.GetWeatherData(loc);

            Assert.AreEqual(WDCheck.cityName, actualCity);
        }
    }
}
