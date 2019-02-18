using System;
using OpenQA.Selenium;

namespace TestFramework.pages.TS_pages
{
    public class TS_CartPage:BasePage
    {
        private static TS_CartPage instance;
        public static TS_CartPage Instance = (instance != null) ? instance : new TS_CartPage();

        public TS_CartPage()
        {
            pageURL = "/checkout/cart";
            pageTitle = "Shopping Cart | Tomorrow Sleep";
        }

        //*Page Elements*//
        By proceedToCheckuotButton = By.CssSelector("button[data-role='proceed-to-checkout']");

        //*Page Methods*//
        public TS_CheckoutPage proceedToCheckuot()
        {
            clickOnElement(proceedToCheckuotButton);
            return TS_CheckoutPage.Instance;
        }
    }
}
