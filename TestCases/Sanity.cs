using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestFramework;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace TestCases
{
    [TestFixture]
    public class Sanity : BaseTest
    {
        [Test]
        public void checkGoogle()
        {
            TestMethod();
            //Browsers.getDriver.FindElement(By.Id("list-ib")).SendKeys("Test");
            //Browsers.getDriver.FindElement(By.Id("list-ib")).SendKeys(Keys.Enter);
        }
    }
}
