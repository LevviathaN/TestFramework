using System;
namespace TestFramework.pages
{
    public class CheckoutPage
    {
        private static CheckoutPage instance;
        public static CheckoutPage Instance = (instance != null) ? instance : new CheckoutPage();

        public CheckoutPage()
        {
        }
    }
}
