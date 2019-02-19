using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RelevantCodes.ExtentReports;

using TestFramework.utils;
using TestFramework.pages;

namespace TestFramework
{
    [TestFixture]
    public class BaseTest
    {
        private ReportingTasks reporter;

        [SetUp]
        public void startTest()
        {
            Console.WriteLine("Set Up");
            reporter.InitializeTest();

        }

        [TearDown]
        public void endTest()
        {
            Console.WriteLine("Tear Down");
            reporter.FinalizeTest();
        }


        [OneTimeSetUp]
        public void beginReporting()
        {
            Console.WriteLine("One Time Set Up");
            DriverProvider.Init();
            BasePage.thread.Value = DriverProvider.getDriver;

            reporter.Instance.LoadConfig(Directory.GetParent(TestContext.CurrentContext.TestDirectory).Parent.FullName + "\\extent-config.xml");
            reporter = new ReportingTasks();

        }

        [OneTimeTearDown]
        public void finishReporting()
        {
            Console.WriteLine("One Time Tear Down");
            DriverProvider.Close();
            reporter.CleanUpReporting();
        }

    }
}
