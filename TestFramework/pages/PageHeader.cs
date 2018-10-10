using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using TestFramework.pages;
using TestFramework.utils;

namespace TestFramework.pages
{
    public class PageHeader
    {
        /*Page Objects*/
        [FindsBy(How = How.XPath, Using = "(.//A[@class='nav-link'])[1]")]
        private IWebElement products;

        [FindsBy(How = How.XPath, Using = ".//A[@class='nav-link active d-flex flex-column justify-content-center'][text()='Mattresses']")]
        private IWebElement mattresses;

        /*Page Methods*/
        public static MattressPlp openMattressPlp()
        {

            return MattressPlp.Instance;
        }
    }
}
