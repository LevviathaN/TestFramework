using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestFramework
{
    [TestFixture]
    public class BaseTest
    {
        IWebDriver driver;

        [OneTimeSetUp]
        public void startTest()
        {
            Browsers.Init();
        }

        [OneTimeTearDown]
        public void endTest()
        {
            Browsers.Close();
        }

        [Test]
        public void TestMethod()
        {
            // TODO: Add your test code here
            Assert.Pass("Your first passing test");
            driver.FindElement(By.XPath(".//*[@class='gsfi']")).SendKeys("Test");

        }
    }
}
