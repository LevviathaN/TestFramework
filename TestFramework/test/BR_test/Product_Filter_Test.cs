using System;
using System.IO;
using NUnit.Framework;
using OpenQA.Selenium;
using TestFramework.utils;
using TestFramework.pages;
using RelevantCodes.ExtentReports;
using System.Configuration;

namespace TestFramework.test
{
    [TestFixture]
    public class Product_Filter_Test:BaseTest
    {
        [Test]
        public void moveTypeSliderTest()
        {
            UserEntity user = UserEntity.getUser(@"/data/user.json");
        }

        [Test]
        public void movePriceSliderTest()
        {
            Console.WriteLine("Move Price Slider Test Method execution");
            Console.WriteLine("https://bettersleep:stg-tsleep-@45@br.tomorrowsleep.com");
            Console.WriteLine(ConfigurationManager.AppSettings["base_url"]);
        }
    }
}
