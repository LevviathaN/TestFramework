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
        private static PageHeader instance;
        public static PageHeader Instance = (instance != null) ? instance : new PageHeader();

        /*Page Objects*/
        By products = By.XPath("(.//A[@class='nav-link'])[1]");
        By mattresses = By.XPath(".//A[@class='nav-link active d-flex flex-column justify-content-center'][text()='Mattresses']");
        By black = By.XPath(".//a[text()='Black']");


        /*Page Methods*/
        /// <summary>
        /// Opens the mattress plp.
        /// </summary>
        /// <returns>The mattress plp.</returns>
        public MattressPlp openMattressPlp()
        {
            hoverAndClick(products, mattresses);
            return MattressPlp.Instance;
        }

        /// <summary>
        /// Opens the black plp.
        /// </summary>
        /// <returns>The black plp.</returns>
        public BlackPlp openBlackPlp()
        {
            hoverAndClick(products, mattresses, black);
            return BlackPlp.Instance;
        }

    }
}
