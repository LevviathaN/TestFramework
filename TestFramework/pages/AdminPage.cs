using System;
namespace TestFramework.pages
{
    public class AdminPage
    {
        private static AdminPage instance;
        public static AdminPage Instance = (instance != null) ? instance : new AdminPage();

        public AdminPage()
        {
        }
    }
}
