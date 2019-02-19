using System;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using RelevantCodes.ExtentReports;


namespace TestFramework.utils
{
    public class ReportingTasks
    {
        private static string fileName = DateTime.Now.ToString("dd'-'MM'-'yy") + " " + DateTime.Now.ToString("t");
        private static ExtentReports _extent = new ExtentReports(TestContext.CurrentContext.TestDirectory + fileName + ".html");
        private ExtentTest _test;

        /// <summary>Property to return the instance of the report.</summary>
        /// <value>The instance</value>
        public static ExtentReports Instance
        {
            get{return _extent;}
        }

        /// <summary>
        /// Initializes the test for reporting.
        /// runs at the beginning of every test
        /// </summary>
        public void InitializeTest()
        {
            _test = _extent.StartTest(TestContext.CurrentContext.Test.Name);
        }

        /// <summary>
        /// Finalizes the test.
        /// Runs at the end of every test
        /// </summary>
        public void FinalizeTest()
        {
            var status = TestContext.CurrentContext.Result.Outcome.Status;
            var stacktrace = string.IsNullOrEmpty(TestContext.CurrentContext.Result.StackTrace)
                ? ""
                : string.Format("<pre>{0}</pre>", TestContext.CurrentContext.Result.Message);
            LogStatus logstatus;

            switch (status)
            {
                case TestStatus.Failed:
                    logstatus = LogStatus.Fail;
                    break;
                case TestStatus.Inconclusive:
                    logstatus = LogStatus.Warning;
                    break;
                case TestStatus.Skipped:
                    logstatus = LogStatus.Skip;
                    break;
                default:
                    logstatus = LogStatus.Pass;
                    break;
            }
            _test.Log(logstatus, "Test ended with " + logstatus + stacktrace);
            _extent.EndTest(_test);
            _extent.Flush();
        }

        /// <summary>
        /// Cleans up reporting.
        /// Runs after all the test finishes
        /// </summary>
        public void CleanUpReporting()
        {
            _extent.Close();
        }

        /// <summary>
        /// Log information.
        /// </summary>
        /// <param name="details">Details.</param>
        public void info(string details)
        {
            _test.Log(LogStatus.Info, details);
        }
    }
}
