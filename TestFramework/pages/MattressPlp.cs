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
        public static MattressPlp Instance;

        public MattressPlp()
        {
        }

        /* Page elements */
        [FindsBy(How = How.CssSelector, Using = "a.action.compare.primary.btn")]
        private IWebElement compareButton;

        [FindsBy(How = How.CssSelector, Using = ".action-primary.action-accept")]
        private IWebElement confirmSelectionRemoval;

        /* Page methods */
        
    }
}
