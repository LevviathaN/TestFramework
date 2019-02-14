using System;
namespace TestFramework.pages.TS_pages
{
    public class MagazinePage:BasePage
    {
        private static MagazinePage instance;
        public static MagazinePage Instance = (instance != null) ? instance : new MagazinePage();

        public MagazinePage()
        {
        }
    }
}
