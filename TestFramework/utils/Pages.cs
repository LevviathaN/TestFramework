using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using TestFramework.pages;
using TestFramework.utils;

namespace TestFramework.utils
{
    public class Pages
    {
        private static T getPages<T>() where T : new()
        {
            var page = new T();
            PageFactory.InitElements(DriverProvider.getDriver, page);
            return page;
        }

        public static MattressPlp mattressPlp
        {
            get { return getPages<MattressPlp>(); }
        }

        public static BlackPlp blackPlp
        {
            get { return getPages<BlackPlp>(); }
        }
    }
}
