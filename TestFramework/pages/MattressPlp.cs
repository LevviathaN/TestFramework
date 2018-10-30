using System;
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

        public MattressPlp()
        {
            pageURL = "/mattresses";
            pageTitle = "BR Mattresses";
        }


        /* Page elements */
        By addToCompareButton = By.XPath("(.//span[text()='Compare +'])[7]");
        By compareButton = By.CssSelector("a.action.compare.primary.btn");
        By confirmSelectionRemoval = By.CssSelector(".action-primary.action-accept");
        By shopNowButton = By.XPath(".//div[@class='ViewDetails']");


        /* Page methods */
        /// <summary>
        /// Adds to compare.
        /// </summary>
        public void addToCompare()
        {
            scrollToView(addToCompareButton);
            clickOnElement(addToCompareButton);
        }

        /// <summary>
        /// Shops the now.
        /// </summary>
        public void shopNow()
        {
            scrollToView(shopNowButton);
            clickOnElement(shopNowButton);
        }
    }
}
