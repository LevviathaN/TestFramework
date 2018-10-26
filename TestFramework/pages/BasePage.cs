using System;
using System.IO;
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
        public const string BASE_URL = "https://br.tomorrowsleep.com";
        public string pageURL = "";
        public string pageTitle = "";

        public static ThreadLocal<IWebDriver> thread = new ThreadLocal<IWebDriver>();
        public static IWebDriver driver() {return thread.Value;}
        //public static IJavaScriptExecutor js = (IJavaScriptExecutor)driver;

        public static int DEFAULT_TIMEOUT = getTimeout();
        public static int SHORT_TIMEOUT = getShortTimeout();
        public static int STATIC_TIMEOUT = getStaticTimeout();

        public static string
        mouseOverScript = "if(document.createEvent){var evObj = document.createEvent('MouseEvents');evObj.initEvent('mouseover',true, false); arguments[0].dispatchEvent(evObj);} else if(document.createEventObject) { arguments[0].fireEvent('onmouseover');}",
        mouseOverScript2 = "var evObj = document.createEvent('MouseEvents'); evObj.initMouseEvent(\"mouseover\",true, false, window, 0, 0, 0, 0, 0, false, false, false, false, 0, null); arguments[0].dispatchEvent(evObj);",
        clickScript = "arguments[0].click();",
        DragNdropScript = "var ball = document.getElementById('ball'); ball.style.position = 'absolute'; moveAt(e); ";


        private static int getTimeout()
        {
            //string timeout = FileIO.getConfigProperty("DefaultTimeoutInSeconds");
            string timeout = "15";
            if (timeout == null)
            {
                //reporter.fatalFail("DefaultTimeoutInSeconds parameter was not found");
                Console.WriteLine("DefaultTimeoutInSeconds parameter was not found");
                timeout = "15";
            };

            return Int32.Parse(timeout);
        }

        private static int getShortTimeout()
        {
            //string timeout = FileIO.getConfigProperty("ShortTimeoutInSeconds");
            string timeout = "3";
            if (timeout == null)
            {
                timeout = "3";
            };

            return Int32.Parse(timeout);
        }

        private static int getStaticTimeout()
        {
            //string timeout = FileIO.getConfigProperty("StaticTimeoutMilliseconds");
            string timeout = "3";
            if (timeout == null)
            {
                timeout = "1000";
            };
            return Int32.Parse(timeout);
        }



        /*--------------------------------------------------------------------------*
         *----------------------------Basic assertion---------------------------------*
         *--------------------------------------------------------------------------*/
        /// <summary>
        /// Ises the page loaded.
        /// </summary>
        /// <returns><c>true</c>, if page loaded was ised, <c>false</c> otherwise.</returns>
        public bool isPageLoaded()
        {
            bool result = false;
            //reporter.info("Page title is: " + driver().getTitle());
            //reporter.info("Page URL is: " + driver().getCurrentUrl());
            if (driver().Title.Contains(pageTitle))
                result = true;
            else{
                //reporter.info("Expected title: " + pageTitle);
                result = false;
            }

            if (driver().Url.Contains(pageURL))
                result = true;
            else
            {
                //reporter.info("Expected URL: " + pageURL);
                result = false;
            }
            return result;
        }

        public bool isElementPresentAndDisplay(By by)
        {
            try
            {
                return findElementIgnoreException(by).isDisplayed();
            }
            catch (Exception e)
            {
                return false;
            }
        }



        /*--------------------------------------------------------------------------*
         *----------------------------Basic actions---------------------------------*
         *--------------------------------------------------------------------------*/
        /// <summary>
        /// Open this instance.
        /// </summary>
        public void open()
        {
            //reporter.info("Opening the page: " + "\"" + BASE_URL + pageURL + "\"");
            //if (FileIO.getConfigProperty("EnvType").equals("Staging"))
            int a = 1;
            if (a==1)
            {
                driver().Url =("https://bettersleep:stg-tsleep-@45@br.tomorrowsleep.com" + pageURL);
                closeWelcomeMessage();
            }
            else
            {
                Cookie A_B_test = new Cookie("cxl_exp_1564305_var", "0");
                driver().Url = BASE_URL + pageURL;
                //driver().Manage().Cookies(A_B_test);
                waitForPageToLoad();
                closeWelcomeMessage();
            }
        }

        public HomePage closeWelcomeMessage()
        {
            //reporter.info("Closing welcome popup");
            waitForPageToLoad();
            if (isElementPresentAndDisplay(By.XPath("//SPAN[@class='close-button']")))
            {
                clickOnElementIgnoreException(By.XPath("//SPAN[@class='close-button']"));
            }
            return HomePage.Instance;
        }

        /// <summary>
        /// Hovers the first element and clicks second.
        /// </summary>
        /// <param name="toHover">To hover.</param>
        /// <param name="toClick">To click.</param>
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

        /// <summary>
        /// Hovers the and click.
        /// </summary>
        /// <param name="toHover1">To hover1.</param>
        /// <param name="toHover2">To hover2.</param>
        /// <param name="toClick">To click.</param>
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

        /// <summary>
        /// Hover the specified element.
        /// </summary>
        /// <returns>The hover.</returns>
        /// <param name="element">Element.</param>
        public static IWebElement hover(IWebElement element)
        {
            ((IJavaScriptExecutor)driver()).ExecuteScript(mouseOverScript, element);
            return element;
        }

        /// <summary>
        /// Click the specified element.
        /// </summary>
        /// <returns>The click.</returns>
        /// <param name="element">Element.</param>
        public static IWebElement click(IWebElement element)
        {
            ((IJavaScriptExecutor)driver()).ExecuteScript(clickScript, element);
            return element;
        }

        /// <summary>
        /// Drags and drop specified element
        /// </summary>
        /// <returns>The ndrop.</returns>
        /// <param name="element">Element.</param>
        public static IWebElement dragNdrop(IWebElement element)
        {
            ((IJavaScriptExecutor)driver()).ExecuteScript(DragNdropScript, element);
            return element;
        }

        /// <summary>
        /// Waits for page to load.
        /// </summary>
        public static void waitForPageToLoad()
        {
            bool pageIsLoaded = ((IJavaScriptExecutor)driver()).ExecuteScript("return document.readyState").Equals("complete");
            IWait<IWebDriver> wait = new WebDriverWait(driver(), TimeSpan.FromSeconds(DEFAULT_TIMEOUT));
        }

        /// <summary>
        /// Thread sleep
        /// </summary>
        /// <param name="timeout">Timeout.</param>
        public static void sleepFor(int timeout)
        {
            try
            {
                Thread.Sleep(timeout);
            }
            catch (ThreadInterruptedException e)
            {
            }
        }


        /// <summary>
        /// Finds the element ignore exception.
        /// </summary>
        /// <returns>The element ignore exception.</returns>
        /// <param name="element">Element.</param>
        public static IWebElement findElementIgnoreException(By element)
        //public static IWebElement findElementIgnoreException(By element, int[] timeout) don't understand meaning and purpose of int[] (int... in java)
        {
            waitForPageToLoad();
            //int timeoutForFindElement = timeout.Length < 1 ? DEFAULT_TIMEOUT : timeout[0];
            int timeoutForFindElement = DEFAULT_TIMEOUT;
            waitForPageToLoad();
            try
            {
                //synchronize();
                (new WebDriverWait(driver(), TimeSpan.FromSeconds(timeoutForFindElement)))
                        .Until(ExpectedConditions.VisibilityOfAllElementsLocatedBy(element));
                return driver().FindElement(element);
            }
            catch (Exception e)
            {
                return null;
            }
        }

        /// <summary>
        /// Clicks the element ignore exception.
        /// </summary>
        /// <returns>The element ignore exception.</returns>
        /// <param name="element">Element.</param>
        /// <param name="timeout">Timeout.</param>
        public static void clickOnElementIgnoreException(By element)

        {
            //public static IWebElement clickElementIgnoreException(By element, int[] timeout) don't understand meaning and purpose of int[] (int... in java)
            waitForPageToLoad();
            //int timeoutForFindElement = timeout.Length < 1 ? DEFAULT_TIMEOUT : timeout[0];
            int timeoutForFindElement = DEFAULT_TIMEOUT;
            waitForPageToLoad();
            try
            {
                //synchronize();
                (new WebDriverWait(driver(), TimeSpan.FromSeconds(timeoutForFindElement)))
                        .Until(ExpectedConditions.VisibilityOfAllElementsLocatedBy(element));
                driver().FindElement(element).Click();
            }
            catch (Exception e)
            {
                Console.WriteLine("error");
            }
        }
    }
}
