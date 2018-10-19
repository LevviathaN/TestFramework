using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using TestFramework.pages;
using TestFramework.utils;

namespace TestFramework.pages
{
    public class BlackPlp:BasePage
    {
        private static BlackPlp instance;
        public static BlackPlp Instance = (instance != null) ? instance : new BlackPlp();

        public BlackPlp()
        {
        }

        //public static IWebElement shopNowButton = DriverProvider.getDriver.FindElement(By.XPath("(.//a[text()='Shop now'])[1]"));

        //public static void clickOnProduct()
        //{
        //    shopNowButton.Click();
        //}
    }
}
