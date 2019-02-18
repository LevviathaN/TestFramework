using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Remote;
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

using TestFramework.utils;

namespace TestFramework
{
    public class DriverProvider
    { 
        private static IWebDriver webDriver;
        public static ReportingTasks reports;
        public static string baseURL = ConfigurationManager.AppSettings["site"] == "TS" ? ConfigurationManager.AppSettings["ts_base_url"] : ConfigurationManager.AppSettings["br_base_url"];
        public static string browser = ConfigurationManager.AppSettings["browser"];
        private static FirefoxDriverService service = FirefoxDriverService.CreateDefaultService(Directory.GetParent(TestContext.CurrentContext.TestDirectory).Parent.FullName + "/drivers"); // location of the geckdriver.exe file

        /// <summary>
        /// Initiate WebDriver object with driver of browser, set in properties file.
        /// </summary>
        public static void Init()
        {
            switch (browser)
            {
                case "Chrome":
                    ChromeOptions chromeOptions = new ChromeOptions();
                    //chromeOptions.AddArguments("--kiosk");
                    chromeOptions.AddArguments("--start-maximized");
                    //chromeOptions.AddArguments("--start-fullscreen");
                    //chromeOptions.AddArguments("--headless");
                    //chromeOptions.AddArguments("--window-size=1920,1080");
                    //chromeOptions.AddArgument("port=8000");
                    webDriver = new ChromeDriver(chromeOptions);
                    break;
                case "IE":
                    webDriver = new InternetExplorerDriver();
                    break;
                case "Firefox":
                    webDriver = new FirefoxDriver(service);
                    break;
            }
            //webDriver.Manage().Window.Maximize();
            //Goto(baseURL);
        }

        /// <summary>
        /// Returns title of the page.
        /// </summary>
        /// <value>The title.</value>
        public static string Title
        {
            get { return webDriver.Title; }
        }

        public static IWebDriver getDriver
        {
            get { return webDriver; }
        }

        public static void Goto(string url)
        {
            webDriver.Url = url;
        }

        public static void Close()
        {
            webDriver.Quit();
        }

        /// <summary>
        /// Returns type of current OS
        /// </summary>
        /// <returns>The os.</returns>
        public static string GetOS()
        {
            OperatingSystem os = Environment.OSVersion;
            PlatformID pid = os.Platform;
            switch (pid)
            {
                case PlatformID.Win32NT:
                case PlatformID.Win32S:
                case PlatformID.Win32Windows:
                case PlatformID.WinCE:
                    return "Windows";
                case PlatformID.Unix:
                    return "Linux";
                case PlatformID.MacOSX:
                    return "Mac";
                default:
                    return "Mac";
            }
        }
    }
}
