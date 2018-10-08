using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestFramework
{
    public class Browsers
    {
        private static IWebDriver webDriver;
        public static ReportsManager reports;
        private static string baseURL = "https://www.google.com/";
        private static string browser = "Chrome";

        public static void Init()
        {
            switch (browser)
            {
                case "Chrome":
                    webDriver = new ChromeDriver();
                    break;
//                case "IE":
//                    webDriver = new InternetExplorerDriver();
//                    break;
                case "Firefox":
                    webDriver = new FirefoxDriver();
                    break;
            }
            webDriver.Manage().Window.Maximize();
            reports = new ReportsManager(browser, baseURL);
            Goto(baseURL);
        }

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
            reports.verifyURL(url);
        }

        public static void Close()
        {
            webDriver.Quit();
        }
    }
}
