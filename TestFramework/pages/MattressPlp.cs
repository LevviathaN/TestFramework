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
        By addToCompareButton = By.XPath("(.//span[text()='Compare +'])[3]");
        By compareButton = By.CssSelector("a.action.compare.primary.btn");
        By confirmSelectionRemoval = By.CssSelector(".action-primary.action-accept");

        //[FindsBy(How = How.XPath, Using = ".//span[text()='Compare +']")]
        //private IWebElement addToCompareButton;

        //[FindsBy(How = How.XPath, Using = ".//div[@class='ViewDetails']")]
        //private IWebElement shopNowButton;


        /* Page methods */
        public void addToCompare()
        {
            click(addToCompareButton);
        }

        public void shopNow()
        {
            click(shopNowButton);
        }


    }
}
