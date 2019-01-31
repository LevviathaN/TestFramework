using System;
using System.IO;
using NUnit.Framework;
using OpenQA.Selenium;
using TestFramework.utils;
using TestFramework.pages;
using RelevantCodes.ExtentReports;
using OpenQA.Selenium.Support.PageObjects;

namespace TestFramework.test.full_test
{
    [TestFixture]
    public class Black_Calista_Mattress_Full_Test:BaseTest 
    {
        [Test]
        public void black_calista_mattress_full_test()
        {
            ProductPage product = ProductPage.Instance;
            PageHeader header = PageHeader.Instance;
            CartPage cart = CartPage.Instance;
            CheckoutPage checkout = CheckoutPage.Instance;
            AdminPage admin = AdminPage.Instance;
        }
    }
}
