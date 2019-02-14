using System;
namespace TestFramework.pages
{
    public class CartPage
    {
        private static CartPage instance;
        public static CartPage Instance = (instance != null) ? instance : new CartPage();

        public CartPage()
        {
        }
    }
}
