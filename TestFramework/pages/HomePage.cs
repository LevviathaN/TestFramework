using System;
namespace TestFramework.pages
{
    public class HomePage:BasePage
    {
        private static HomePage instance;
        public static HomePage Instance = (instance != null) ? instance : new HomePage();

        public HomePage()
        {
            pageURL = "/";
            pageTitle = "BR Home";
        }
    }
}
