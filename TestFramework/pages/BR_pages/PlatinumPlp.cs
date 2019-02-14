using System;
namespace TestFramework.pages
{
    public class PlatinumPlp:BasePage
    {
        private static PlatinumPlp instance;
        public static PlatinumPlp Instance = (instance != null) ? instance : new PlatinumPlp();

        public PlatinumPlp()
        {
            pageURL = "/platinum";
            pageTitle = "Platinum";
        }
    }
}
