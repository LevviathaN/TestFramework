using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.PageObjects;
using TestFramework.pages;
using TestFramework.utils;

namespace TestFramework.pages
{
    public class BasePage
    {
        public BasePage()
        {

        }

        public static void hoverAndClick(IWebElement toHover, IWebElement toClick)
        {
            IWebDriver driver = new ChromeDriver();
            Actions builder = new Actions(driver);
            builder.MoveToElement(toHover).Perform();
            toClick.Click();
        }

        public static void hoverAndClick(IWebElement toHover1, IWebElement toHover2, IWebElement toClick)
        {
            IWebDriver driver = new ChromeDriver();
            Actions builder = new Actions(driver);
            builder.MoveToElement(toHover1).Perform();
            builder.MoveToElement(toHover2).Perform();
            toClick.Click();
        }
    }
}
