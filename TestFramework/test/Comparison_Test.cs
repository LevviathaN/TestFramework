using System;
using System.IO;
using NUnit.Framework;
using OpenQA.Selenium;
using TestFramework.utils;
using TestFramework.pages;
using RelevantCodes.ExtentReports;
using OpenQA.Selenium.Support.PageObjects;

namespace TestFramework.test
{
    [TestFixture]
    public class Comparison_Test:BaseTest
    {
        [Test]
        public void comparisonTest()
        {
            PageHeader header = PageHeader.Instance;
            MattressPlp mattressPlp = MattressPlp.Instance;

            Console.WriteLine("Comparison Test Method execution");
            header.open();
            header.openMattressPlp();
            mattressPlp.addToCompare();
        }
    }
}
