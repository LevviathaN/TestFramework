using System;
using OpenQA.Selenium;

namespace TestFramework.pages.TS_pages
{
    public class TS_ShopPlp:BasePage
    {
        private static TS_ShopPlp instance;
        public static TS_ShopPlp Instance = (instance != null) ? instance : new TS_ShopPlp();

        public TS_ShopPlp()
        {
            pageURL = "/shop";
            pageTitle = "Shop Sleep System Products | Tomorrow Sleep";
        }

        public TS_ProductPage SelectProductIcon(string product)
        {
            clickOnElement(By.XPath(string.Format(".//ul[@class='shop-icons']/*/*/p[text()='{0}']", product)));
            return TS_ProductPage.Instance;
        }

        public TS_ProductPage SelectProductFromList(string product)
        {
            clickOnElement(By.XPath(string.Format(".//a[text()='SHOP Our {0}']", product)));
            return TS_ProductPage.Instance;
        }
    }
}
