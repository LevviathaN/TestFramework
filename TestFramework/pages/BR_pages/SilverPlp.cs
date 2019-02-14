using System;
namespace TestFramework.pages
{
    public class SilverPlp:BasePage
    {
        private static SilverPlp instance;
        public static SilverPlp Instance = (instance != null) ? instance : new SilverPlp();

        public SilverPlp()
        {
            pageURL = "/silver";
            pageTitle = "Silver";
        }
    }
}
