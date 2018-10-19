using System;
using System.IO;
using NUnit.Framework;
using OpenQA.Selenium;
using TestFramework.utils;
using TestFramework.pages;
using RelevantCodes.ExtentReports;

namespace TestFramework.test
{
    [TestFixture]
    public class Comparison_Test:BaseTest
    {
        [Test]
        public void comparisonTest()
        {
            PageHeader.openBlackPlp();
        }
    }
}
