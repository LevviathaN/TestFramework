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

namespace TestFramework
{
    [TestFixture]
    public class BaseTest
    {
        private ReportingTasks reporter;

        [SetUp]
        public void startTest()
        {
            DriverProvider.Init();
            reporter.InitializeTest();
        }

        [TearDown]
        public void endTest()
        {
            DriverProvider.Close();
            reporter.FinalizeTest();
        }


        [OneTimeSetUp]
        public void beginReporting()
        {
            ExtentReports extentReports = ReportingManager.Instance;
            extentReports.LoadConfig(Directory.GetParent(TestContext.CurrentContext.TestDirectory).Parent.FullName + "\\extent-config.xml");
            reporter = new ReportingTasks(extentReports);
        }

        [OneTimeTearDown]
        public void finishReporting()
        {
            reporter.CleanUpReporting();
        }
    }
}
