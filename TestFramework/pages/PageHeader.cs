﻿using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using TestFramework.pages;
using TestFramework.utils;


namespace TestFramework.pages
{
    public class PageHeader:BasePage
    {
        public static PageHeader instance;
        public static PageHeader Instance = (instance != null) ? instance : new PageHeader();

        /*Page Objects*/
        //private static IWebElement 
        //products = DriverProvider.getDriver.FindElement(By.XPath("(.//A[@class='nav-link'])[1]")),
        //mattresses = DriverProvider.getDriver.FindElement(By.XPath(".//A[@class='nav-link active d-flex flex-column justify-content-center'][text()='Mattresses']")),
        //black = DriverProvider.getDriver.FindElement(By.XPath(".//a[text()='Black']"));

        [FindsBy(How = How.XPath, Using = "(.//A[@class='nav-link'])[1]")]
        private IWebElement products;

        [FindsBy(How = How.XPath, Using = ".//A[@class='nav-link active d-flex flex-column justify-content-center'][text()='Mattresses']")]
        private IWebElement mattresses;

        [FindsBy(How = How.XPath, Using = ".//a[text()='Black']")]
        private IWebElement black;


        /*Page Methods*/
        public MattressPlp openMattressPlp()
        {
            hoverAndClick(products, mattresses);
            return MattressPlp.Instance;
        }

        public BlackPlp openBlackPlp()
        {
            hoverAndClick(products, mattresses, black);
            return BlackPlp.Instance;
        }

    }
}
