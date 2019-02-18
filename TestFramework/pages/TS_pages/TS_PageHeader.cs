using System;
using OpenQA.Selenium;

namespace TestFramework.pages.TS_pages
{
    public class TS_PageHeader:BasePage
    {
        private static TS_PageHeader instance;
        public static TS_PageHeader Instance = (instance != null) ? instance : new TS_PageHeader();

        /*Page Objects*/
        By shop = By.XPath(".//a[text()='Shop']");
        By hybridMattress = By.XPath(".//a[text()='Hybrid Mattress']");
        By memoryFoamMattress = By.XPath(".//A[@class='nav-link active d-flex flex-column justify-content-center'][text()='Mattresses']");
        By mattressProtector = By.XPath(".//a[text()='Black']");
        By adjustableBed = By.XPath(".//a[text()='Platinum']");
        By platformBed = By.XPath(".//a[text()='Silver']");
        By memoryFoamPillow = By.XPath(".//a[text()='Silver']");
        By plushPillow = By.XPath(".//a[text()='Silver']");
        By sheetSet = By.XPath(".//a[text()='Silver']");
        By comforter = By.XPath(".//a[text()='Silver']");
        By sleepTracker = By.XPath(".//a[text()='Silver']");
        By curtains = By.XPath(".//a[text()='Silver']");


        /*Page Methods*/
        /// <summary>
        /// Opens desired PDP.
        /// </summary>
        /// <returns>The mattress plp.</returns>
        /// <param name="product">Product.</param>
        public TS_ProductPage openPDP(string product)
        {
            hoverAndClick(shop, hybridMattress);
            return TS_ProductPage.Instance;
        }
    }
}
