using System;
using System.IO;
using System.Threading;
using System.Configuration;
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
        public string BASE_URL = ConfigurationManager.AppSettings["base url"];
        public string pageURL = "";
        public string pageTitle = "";

        public static ThreadLocal<IWebDriver> thread = new ThreadLocal<IWebDriver>();
        public static IWebDriver driver() {return thread.Value;}

        public static int DEFAULT_TIMEOUT = getTimeout();
        public static int SHORT_TIMEOUT = getShortTimeout();
        public static int STATIC_TIMEOUT = getStaticTimeout();

        public static string
        mouseOverScript = "if(document.createEvent){var evObj = document.createEvent('MouseEvents');evObj.initEvent('mouseover',true, false); " +
        	"arguments[0].dispatchEvent(evObj);} else if(document.createEventObject) { arguments[0].fireEvent('onmouseover');}",
        mouseOverScript2 = "var evObj = document.createEvent('MouseEvents'); " +
        	"evObj.initMouseEvent(\"mouseover\",true, false, window, 0, 0, 0, 0, 0, false, false, false, false, 0, null); arguments[0].dispatchEvent(evObj);",
        clickScript = "arguments[0].click();",
        DragNdropScript = "var ball = document.getElementById('ball'); ball.style.position = 'absolute'; moveAt(e); ";


        /// <summary>
        /// Gets the timeout.
        /// </summary>
        /// <returns>The timeout.</returns>
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

        /// <summary>
        /// Gets the short timeout.
        /// </summary>
        /// <returns>The short timeout.</returns>
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

        /// <summary>
        /// Gets the static timeout.
        /// </summary>
        /// <returns>The static timeout.</returns>
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
        /// Check if the page is loaded.
        /// </summary>
        /// <returns><c>true</c>, if page was loaded, <c>false</c> otherwise.</returns>
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

        /// <summary>
        /// Check if element is present and display.
        /// </summary>
        /// <returns><c>true</c>, if element present and display was ised, <c>false</c> otherwise.</returns>
        /// <param name="by">By.</param>
        public bool isElementPresentAndDisplay(By by)
        {
            try
            {
                return findElementIgnoreException(by).Displayed;
            }
            catch (Exception)
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
            driver().Url = DriverProvider.baseURL + pageURL;
            closeWelcomeMessage();
        }

        /// <summary>
        /// Closes the welcome message.
        /// </summary>
        /// <returns>The welcome message.</returns>
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
        public static void hoverAndClick(By toHover, By toClick, params int[] timeout)
        {
            int timeoutForFindElement = timeout.Length < 1 ? DEFAULT_TIMEOUT : timeout[0];
            waitForPageToLoad();
            try
            {
                ((IJavaScriptExecutor)driver()).ExecuteScript(mouseOverScript, driver().FindElement(toHover));
                ((IJavaScriptExecutor)driver()).ExecuteScript(clickScript, driver().FindElement(toClick));
            }
            catch (Exception)
            {
                hoverAndClick(toHover, toClick);
            }
            waitForPageToLoad();
        }

        /// <summary>
        /// Hovers the and click.
        /// </summary>
        /// <param name="toHover1">To hover1.</param>
        /// <param name="toHover2">To hover2.</param>
        /// <param name="toClick">To click.</param>
        public static void hoverAndClick(By toHover1, By toHover2, By toClick, params int[] timeout)
        {
            int timeoutForFindElement = timeout.Length < 1 ? DEFAULT_TIMEOUT : timeout[0];
            waitForPageToLoad();
            try
            {
                ((IJavaScriptExecutor)driver()).ExecuteScript(mouseOverScript, driver().FindElement(toHover1));
                ((IJavaScriptExecutor)driver()).ExecuteScript(mouseOverScript, driver().FindElement(toHover2));
                ((IJavaScriptExecutor)driver()).ExecuteScript(clickScript, driver().FindElement(toClick));
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
        public static By hover(By element, params int[] timeout)
        {
            int timeoutForFindElement = timeout.Length < 1 ? DEFAULT_TIMEOUT : timeout[0];
            waitForPageToLoad();
            try
            {
                (new WebDriverWait(driver(), TimeSpan.FromSeconds(timeoutForFindElement)))
                    .Until(ExpectedConditions.VisibilityOfAllElementsLocatedBy(element));
                ((IJavaScriptExecutor)driver()).ExecuteScript(mouseOverScript, driver().FindElement(element));
            }
            catch (Exception)
            {
                //reporter.fail(Tools.getStackTrace(e));
                throw new Exception("Failure hovering on element");
            }
            waitForPageToLoad();
            return element;
        }
         
        /// <summary>
        /// Drags and drop specified element
        /// </summary>
        /// <returns>The ndrop.</returns>
        /// <param name="element">Element.</param>
        public static By dragNdrop(By element, params int[] timeout)
        {
            int timeoutForFindElement = timeout.Length < 1 ? DEFAULT_TIMEOUT : timeout[0];
            waitForPageToLoad();
            try
            {
                (new WebDriverWait(driver(), TimeSpan.FromSeconds(timeoutForFindElement)))
                    .Until(ExpectedConditions.VisibilityOfAllElementsLocatedBy(element));
                ((IJavaScriptExecutor)driver()).ExecuteScript(DragNdropScript, driver().FindElement(element));
            }
            catch (Exception)
            {
                //reporter.fail(Tools.getStackTrace(e));
                throw new Exception("Failure dragging the element");
            }
            waitForPageToLoad();
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
            catch (ThreadInterruptedException)
            {
            }
        }

        /// <summary>
        /// Finds the element ignore exception.
        /// </summary>
        /// <returns>The element ignore exception.</returns>
        /// <param name="element">Element.</param>
        public static IWebElement findElementIgnoreException(By element, params int[] timeout)
        {
            waitForPageToLoad();
            int timeoutForFindElement = timeout.Length < 1 ? DEFAULT_TIMEOUT : timeout[0];
            waitForPageToLoad();
            try
            {
                //synchronize();
                (new WebDriverWait(driver(), TimeSpan.FromSeconds(timeoutForFindElement)))
                        .Until(ExpectedConditions.VisibilityOfAllElementsLocatedBy(element));
                return driver().FindElement(element);
            }
            catch (Exception)
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
        public static void clickOnElementIgnoreException(By element, params int[] timeout)

        {
            waitForPageToLoad();
            int timeoutForFindElement = timeout.Length < 1 ? DEFAULT_TIMEOUT : timeout[0];
            try
            {
                //synchronize();
                (new WebDriverWait(driver(), TimeSpan.FromSeconds(timeoutForFindElement)))
                        .Until(ExpectedConditions.VisibilityOfAllElementsLocatedBy(element));
                driver().FindElement(element).Click();
            }
            catch (Exception)
            {
                Console.WriteLine("error");
            }
            waitForPageToLoad();
        }

        /// <summary>
        /// Finds the element.
        /// </summary>
        /// <returns>The element.</returns>
        /// <param name="element">Element.</param>
        /// <param name="timeout">Timeout.</param>
        public static IWebElement findElement(By element, params int[] timeout)
        {
            waitForPageToLoad();
            int timeoutForFindElement = timeout.Length < 1 ? DEFAULT_TIMEOUT : timeout[0];
            waitForPageToLoad();
            try
            {
                //synchronize();
                (new WebDriverWait(driver(), TimeSpan.FromSeconds(timeoutForFindElement)))
                        .Until(ExpectedConditions.VisibilityOfAllElementsLocatedBy(element));
                return driver().FindElement(element);
            }
            catch (Exception)
            {
                //reporter.fail(Tools.getStackTrace(e));
                throw new Exception("Failure finding element");
            }
        }

        /// <summary>
        /// Click the specified element.
        /// </summary>
        /// <returns>The click.</returns>
        /// <param name="element">Element.</param>
        public static void clickOnElement(By element, params int[] timeout)
        {
            int timeoutForFindElement = timeout.Length < 1 ? DEFAULT_TIMEOUT : timeout[0];
            waitForPageToLoad();
            try
            {
                (new WebDriverWait(driver(), TimeSpan.FromSeconds(timeoutForFindElement)))
                    .Until(ExpectedConditions.VisibilityOfAllElementsLocatedBy(element));
                driver().FindElement(element).Click();
            }
            catch (Exception)
            {
                //reporter.fail(Tools.getStackTrace(e));
                throw new Exception("Failure clicking on element");
            }
            waitForPageToLoad();
            //((IJavaScriptExecutor)driver()).ExecuteScript(clickScript, element);
        }

        /// <summary>
        /// Switchs to frame (working with iFrames).
        /// </summary>
        /// <param name="xpath">Xpath.</param>
        public void switchToFrame(By xpath)
        {
            //reporter.info("Switch to frame: " + xpath.toString());
            driver().SwitchTo().Frame(findElement(xpath));
        }

        /// <summary>
        /// Switchs the content of the to default. (working with iFrames)
        /// </summary>
        public void switchToDefaultContent()
        {
            //reporter.info("Switch to default content");
            driver().SwitchTo().DefaultContent();
        }

        /// <summary>
        /// Scrolls to XY position.
        /// </summary>
        /// <param name="xPosition">X position.</param>
        /// <param name="yPosition">Y position.</param>
        public void scrollTo(int xPosition = 0, int yPosition = 0)
        {
            var js = String.Format("window.scrollTo({0}, {1})", xPosition, yPosition);
            ((IJavaScriptExecutor)driver()).ExecuteScript(js);
        }

        /// <summary>
        /// Scrolls to view element by selector.
        /// </summary>
        /// <returns>The to view.</returns>
        /// <param name="selector">Selector.</param>
        public IWebElement scrollToView(By selector)
        {
            var element = driver().FindElement(selector);
            scrollToView(element);
            return element;
        }

        /// <summary>
        /// Scrolls to view element.
        /// </summary>
        /// <param name="element">Element.</param>
        public void scrollToView(IWebElement element)
        {
            if (element.Location.Y > 200)
            {
                scrollTo(0, element.Location.Y - 100); // Make sure element is in the view but below the top navigation pane
            }

        }

    }
}
