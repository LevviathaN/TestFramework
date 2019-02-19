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
    public class DebugTest
    {
        [Test]
        public void relativePathDisplayTest()
        {
            Console.WriteLine(Directory.GetCurrentDirectory());
            Console.Write("Used in'ReportingManager' class: ");
            Console.WriteLine(TestContext.CurrentContext.TestDirectory);
            Console.Write("Used in'BaseTest' class: ");
            Console.WriteLine(Directory.GetParent(TestContext.CurrentContext.TestDirectory).Parent.FullName + "\\extent-config.xml");
        }

        [Test]
        public void userEntitiesTest()
        {
            UserEntity user = UserEntity.getUser("/Users/ruslanlevytskyi/Projects/LevviathaN/TestFramework/TestFramework/data/Default_User.json");
            Console.WriteLine(user.Email);
            Console.WriteLine(user.Firstname);
            Console.WriteLine(user.Lastname);
            Console.WriteLine(user.Street);
            Console.WriteLine(user.City);
            Console.WriteLine(user.Phone);
            Console.WriteLine(user.Zipcode);
            Console.WriteLine(user.State);
        }

        [Test]
        public void googleSheetsTest()
        {
            GoogleSheets.run_cmd("/Users/ruslanlevytskyi/Projects/LevviathaN/TestFramework/TestFramework/data/python/quickstart.py", "");
        }
    }
}
