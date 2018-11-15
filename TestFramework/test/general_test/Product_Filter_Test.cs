using System;
using System.IO;
using NUnit.Framework;
using OpenQA.Selenium;
using TestFramework.utils;
using TestFramework.pages;
using RelevantCodes.ExtentReports;

namespace TestFramework.test
{
    [TestFixture]
    public class Product_Filter_Test
    {
        public Product_Filter_Test()
        {
        }

        [Test]
        public void moveTypeSliderTest()
        {
            Console.WriteLine("Move Type Slider Test Method execution");
        }

        [Test]
        public void movePriceSliderTest()
        {
            Console.WriteLine("Move Price Slider Test Method execution");
        }
    }
}
