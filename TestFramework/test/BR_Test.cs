using System;
using System.IO;
using NUnit.Framework;
using OpenQA.Selenium;
using TestFramework.utils;
using RelevantCodes.ExtentReports;

namespace TestFramework.test
{
    [TestFixture]
    public class BR_Test:BaseTest
    {
        [Test]
        public void Test1()
        {
            DriverProvider.getDriver.FindElement(By.XPath("(.//A[@class='nav-link'])[1]")).Click();
        }
    }
}
