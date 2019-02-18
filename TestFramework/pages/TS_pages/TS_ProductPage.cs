using System;
using OpenQA.Selenium;
using TestFramework.pages;

namespace TestFramework.pages.TS_pages
{
    public class TS_ProductPage:BasePage
    {
        private static TS_ProductPage instance;
        public static TS_ProductPage Instance = (instance != null) ? instance : new TS_ProductPage();

        /** UI Mappings */
        By addToCartButton = By.XPath("//button[@id='product-addtocart-button']");
        By updateItemButton = By.XPath("//main[@id='maincontent']//button[@id='product-updatecart-button']");
        By crossSalesWindow = By.XPath("//div[@class='xs-modal']");
        By viewCartButton = By.XPath("//a[@class='__to-checkout button']");

        public TS_CartPage clickAddToCart()
        {
            //reporter.info("Click on \"Add to Cart\" button");
            //header.closeCart();
            waitForPageToLoad();
            clickOnElement(addToCartButton);
            if (isElementPresentAndDisplay(crossSalesWindow))
            {
                clickOnElement(viewCartButton);
            }
            return TS_CartPage.Instance;
        }
    }
}
