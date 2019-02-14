using System;
namespace TestFramework.pages
{
    public class ProductPage
    {
        private static ProductPage instance;
        public static ProductPage Instance = (instance != null) ? instance : new ProductPage();

        public ProductPage()
        {
        }
    }
}
