using System;
using System.IO;
using NUnit.Framework;
using OpenQA.Selenium;
using TestFramework.utils;
using TestFramework.pages;
using RelevantCodes.ExtentReports;
using System.Configuration;

namespace TestFramework.test.general_test
{
    [TestFixture]
    public class SetupTeardownDebugTest:BaseTest
    {
        [Test]
        public void testMethod1()
        {
            Console.WriteLine("Test method 1 execution");
        }

        [Test]
        public void testMethod2()
        {
            Console.WriteLine("Test method 2 execution");
        }

        [Test]
        public void testMethod3()
        {
            Console.WriteLine("Test method 3 execution");
        }

        [Test]
        public void testMethod4()
        {
            Console.WriteLine("Test method 4 execution");
        }
    }
}
