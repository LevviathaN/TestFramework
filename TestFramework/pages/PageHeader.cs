using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using TestFramework.pages;
using TestFramework.utils;


namespace TestFramework.pages
{
    public class PageHeader:BasePage
    {
        /*Page Objects*/
        private static IWebElement 
        products = DriverProvider.getDriver.FindElement(By.XPath("(.//A[@class='nav-link'])[1]")),
        mattresses = DriverProvider.getDriver.FindElement(By.XPath(".//A[@class='nav-link active d-flex flex-column justify-content-center'][text()='Mattresses']"));

        /*Page Methods*/
        public static MattressPlp openMattressPlp()
        {
            hoverAndClick(products, mattresses);
            return MattressPlp.Instance;
        }
    }
}
