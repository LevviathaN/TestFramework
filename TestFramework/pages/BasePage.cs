using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Support.PageObjects;
using TestFramework.pages;
using TestFramework.utils;

namespace TestFramework.pages
{
    public class BasePage
    {
        public static IWebDriver driver = DriverProvider.getDriver;
        public static Actions action = new Actions(driver);
        public static WebDriverWait wait = new WebDriverWait(driver, new TimeSpan(0, 0, 5));

        public static IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
        public static string mouseOverScript = "if(document.createEvent){var evObj = document.createEvent('MouseEvents');evObj.initEvent('mouseover',true, false); arguments[0].dispatchEvent(evObj);} else if(document.createEventObject) { arguments[0].fireEvent('onmouseover');}";
        public static string mouseOverScript2 = "var evObj = document.createEvent('MouseEvents');" +
                "evObj.initMouseEvent(\"mouseover\",true, false, window, 0, 0, 0, 0, 0, false, false, false, false, 0, null);" +
            "arguments[0].dispatchEvent(evObj);";



        public BasePage()
        {

        }

        public static void hoverAndClick(IWebElement toHover, IWebElement toClick)
        {
            try
            {
                js.ExecuteScript(mouseOverScript, toHover);
                toClick.Click();
            }
            catch (Exception)
            {

                hoverAndClick(toHover, toClick);
            }
        }

        public static void hoverAndClick(IWebElement toHover1, IWebElement toHover2, IWebElement toClick)
        {
            try
            {
                js.ExecuteScript(mouseOverScript, toHover1);
                js.ExecuteScript(mouseOverScript, toHover2);
                toClick.Click();
            }
            catch (Exception)
            {
                hoverAndClick(toHover1, toHover2, toClick);
            }
        }

        //public static void waitForElement()
        //{
        //    WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
        //    IWebElement element = wait.Until(
        //    ExpectedConditions.ElementToBeClickable(By.XPath(".//a[text()='Black']")));
        //}
    }
}
