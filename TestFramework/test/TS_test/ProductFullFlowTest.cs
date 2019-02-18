using System;
using System.IO;
using NUnit.Framework;
using TestFramework.utils;
using TestFramework.pages.TS_pages;

namespace TestFramework.test.TS_test
{
    [TestFixture]
    public class ProductFullFlowTest:BaseTest
    {
        [TestCase("Hybrid Mattress")]
        [TestCase("Memory Foam Mattress")]
        [TestCase("Memory Foam Pillow")]
        [TestCase("Plush Pillow")]
        [TestCase("Comforter")]
        [TestCase("Sheet Set")]
        [TestCase("Mattress Protector")]
        [TestCase("Sleeptracker Monitor")]
        [TestCase("Curtains")]
        [TestCase("Adjustable Bed")]
        [TestCase("Platform Bed")]
        public void productFullFlowTest(string productName)
        {
            UserEntity user = UserEntity.getUser("/Users/ruslanlevytskyi/Projects/LevviathaN/TestFramework/TestFramework/data/Default_User.json");
            TS_ShopPlp shop = TS_ShopPlp.Instance;

            shop.open();
            shop.SelectProductIcon(productName)
                .clickAddToCart()
                .proceedToCheckuot()
                .populateAllCheckoutFields(user);
        }
    }
}
