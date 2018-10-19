﻿using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using TestFramework.pages;
using TestFramework.utils;

namespace TestFramework.pages
{
    public class MattressPlp:BasePage
    {
        private static MattressPlp instance;
        public static MattressPlp Instance = (instance != null) ? instance : new MattressPlp();


        /* Page elements */
        //private static IWebElement
        //addToCompareButton = DriverProvider.getDriver.FindElement(By.XPath("(.//span[text()='Compare +'])[3]")),
        //compareButton = DriverProvider.getDriver.FindElement(By.CssSelector("a.action.compare.primary.btn")),
        //confirmSelectionRemoval = DriverProvider.getDriver.FindElement(By.CssSelector(".action-primary.action-accept"));

        [FindsBy(How = How.XPath, Using = "(.//span[text()='Compare +'])[3]")]
        private static IWebElement addToCompareButton;


        /* Page methods */
        public void addToCompare()
        {
            addToCompareButton.Click();
        }
    }
}