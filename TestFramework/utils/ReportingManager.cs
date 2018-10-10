using System;
using NUnit.Framework;
using RelevantCodes.ExtentReports;

namespace TestFramework.utils
{
    /// <summary>Creates a single instance of Extent Report</summary>
    public class ReportingManager
    {
        private static string fileName = DateTime.Now.ToLongDateString();
        /// <summary>Create new instance of Extent report</summary>
        private static readonly ExtentReports _instance = new ExtentReports(TestContext.CurrentContext.TestDirectory + "\\TestResults" + fileName + ".html");

        static ReportingManager() { }
        private ReportingManager() { }

        /// <summary>Property to return the instance of the report.</summary>
        /// <value>The instance</value>
        public static ExtentReports Instance
        {
            get
            {
                return _instance;
            }
        }
    }
}
