using System;
using System.Threading;
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
        public string pageURL = "";
        public string pageTitle = "";

        public static ThreadLocal<IWebDriver> thread = new ThreadLocal<IWebDriver>();
        public static IWebDriver driver() {return thread.Value;}
        //public static IJavaScriptExecutor js = (IJavaScriptExecutor)driver;

        public static string
        mouseOverScript = "if(document.createEvent){var evObj = document.createEvent('MouseEvents');evObj.initEvent('mouseover',true, false); arguments[0].dispatchEvent(evObj);} else if(document.createEventObject) { arguments[0].fireEvent('onmouseover');}",
        mouseOverScript2 = "var evObj = document.createEvent('MouseEvents'); evObj.initMouseEvent(\"mouseover\",true, false, window, 0, 0, 0, 0, 0, false, false, false, false, 0, null); arguments[0].dispatchEvent(evObj);",
        clickScript = "arguments[0].click();";



        public static void hoverAndClick(IWebElement toHover, IWebElement toClick)
        {
            try
            {
                ((IJavaScriptExecutor)driver()).ExecuteScript(mouseOverScript, toHover);
                ((IJavaScriptExecutor)driver()).ExecuteScript(clickScript, toClick);
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
                ((IJavaScriptExecutor)driver()).ExecuteScript(mouseOverScript, toHover1);
                ((IJavaScriptExecutor)driver()).ExecuteScript(mouseOverScript, toHover2);
                ((IJavaScriptExecutor)driver()).ExecuteScript(clickScript, toClick);
            }
            catch (Exception)
            {
                hoverAndClick(toHover1, toHover2, toClick);
            }
        }

        public static IWebElement hover(IWebElement element)
        {
            ((IJavaScriptExecutor)driver()).ExecuteScript(mouseOverScript, element);
            return element;
        }

        public static IWebElement click(IWebElement element)
        {
            ((IJavaScriptExecutor)driver()).ExecuteScript(clickScript, element);
            return element;
        }

        //public static void waitForElement()
        //{
        //    WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
        //    IWebElement element = wait.Until(
        //    ExpectedConditions.ElementToBeClickable(By.XPath(".//a[text()='Black']")));
        //}
    }
}
