using System;
using OpenQA.Selenium;
using TestFramework.utils;

namespace TestFramework.pages.TS_pages
{
    public class TS_CheckoutPage:BasePage
    {
        private static TS_CheckoutPage instance;
        public static TS_CheckoutPage Instance = (instance != null) ? instance : new TS_CheckoutPage();

        public TS_CheckoutPage()
        {
            pageURL = "/checkout";
        }

        By emailField = By.Id("customer-email");
        By lastNameField = By.Name("lastname");
        By firstNameField = By.Name("firstname");
        By companyField = By.Name("company");
        By streetField = By.Name("street[0]");
        By street2Field = By.Name("street[1]");
        By cityField = By.Name("city");
        By postcodeField = By.Name("postcode");
        //select
        By regionSelect = By.Name("region_id");
        //select
        By countrySelect = By.Name("country_id");
        By phoneField = By.Name("telephone");
        By continueButton = By.CssSelector("button.action.continue.primary");

        By freeShippingRadioButton = By.Id("label_method_freeshipping_freeshipping");
        By whiteGloveRadioButton = By.Id("label_method_bestway_tablerate");
        By oldMattressRemovalRadioButton = By.CssSelector("div.value.deliverydate-removel label");
        By firstAvailableDeliveryDay = By.XPath("//td[@data-handler='selectDay'][2]");

        //order list

        //By orderItems = By.CssSelector("div.block.items-in-cart ol.minicart-items li.product-item");
        By orderItems = By.CssSelector("li.product-item");
        By orderItemName = By.CssSelector("span.product-item-Name");
        By orderItemQty = By.CssSelector("span.value");
        By orderItemPrice = By.CssSelector("span.price");
        By orderItemDetails = By.CssSelector("dl.item-options span");
        By shippingPrice = By.CssSelector("span[data-th='Shipping']");


        //payment method
        By paymentIFrame = By.XPath("//iframe[id='braintree-hosted-field-number']");
        By cardRadioButton = By.ClassName("payment-method-title field choice");
        By cardNumber = By.Id("credit-card-number");
        By cardExpMonth = By.Name("expiration-month");
        By cardExpYear = By.Name("expiration-year");
        By cardCVV = By.Name("cvv");
        By paypalRadioButton = By.ClassName("payment-method payment-method-paypal");
        By affirmRadioButton = By.ClassName("payment-method payment-affirm _active");

        By placeOrderButton = By.ClassName("action primary checkout");

        /** Page Methods */
        public void selectFreeShipping()
        {
            //reporter.info("Select free shipping");
            clickOnElement(freeShippingRadioButton);
        }

        public void selectWhiteGloveSpipping()
        {
            //reporter.info("Select White Glove ");
            clickOnElement(whiteGloveRadioButton);
        }

        public void selectOldMattressRemoval()
        {
            //reporter.info("Select Old Mattress removal ");
            clickOnElement(oldMattressRemovalRadioButton);
        }

        public void selectDeliveryDate()
        {
            //reporter.info("Select delivery date");
            clickOnElement(firstAvailableDeliveryDay);
        }

        public string firstAvailableDay()
        {
            return findElement(firstAvailableDeliveryDay).Text;
        }

        public string selectedDate()
        {
            return findElement(By.CssSelector("div[id='datepicker-message-block'] div strong")).Text.Replace("(\\s[0-9]{4}$)", "").Replace("\\D", "");
        }

        public TS_CheckoutPage setEmail(string email)
        {
            //reporter.info("Set Email name: " + email);
            findElement(emailField).SendKeys(email);
            return this;
        }

        public TS_CheckoutPage setLastName(string lastname)
        {
            //reporter.info("Set Last name: " + lastname);
            findElement(lastNameField).SendKeys(lastname);
            return this;
        }

        public TS_CheckoutPage setFirstName(string firstname)
        {
            //reporter.info("Set First name: " + firstname);
            findElement(firstNameField).SendKeys(firstname);
            return this;
        }


        public TS_CheckoutPage setCompany(string company)
        {
            //reporter.info("Set Company name: " + company);
            findElement(companyField).SendKeys(company);
            return this;
        }

        public TS_CheckoutPage setStreet(string street)
        {
            //reporter.info("Set Street name: " + street);
            findElement(streetField).SendKeys(street);
            return this;
        }

        public TS_CheckoutPage setStreet2(string street2)
        {
            //reporter.info("Set Street details: " + street2);
            setText(street2Field, street2);
            return this;
        }

        public TS_CheckoutPage setCity(string city)
        {
            //reporter.info("Set City name: " + city);
            findElement(cityField).SendKeys(city);
            return this;
        }


        public TS_CheckoutPage selectCountry(string country)
        {
            //reporter.info("Select Country name: " + country);
            //selectFromDropdown(countrySelect, country);
            findElement(countrySelect).SendKeys(country);
            return this;
        }

        public TS_CheckoutPage selectRegion(string region)
        {
            //reporter.info("Select Region name: " + region);
            //selectFromDropdown(regionSelect, region);
            findElement(regionSelect).SendKeys(region);
            return this;
        }

        public TS_CheckoutPage setPostcode(string postcode)
        {
            //reporter.info("Set Postcode name: " + postcode);
            findElement(postcodeField).SendKeys(postcode);
            return this;
        }

        public TS_CheckoutPage setPhone(string phone)
        {
            //reporter.info("Set Phone name: " + phone);
            findElement(phoneField).SendKeys(phone);
            return this;
        }

        public string getShippingPrice()
        {
            waitForPageToLoad();
            //reporter.info("Check shipping price");
            return findElement(shippingPrice).Text;
        }

        public TS_CheckoutPage setCardNumber()
        {
            //reporter.info("Set Card Number: 4189813968238783");
            switchToFrame(By.XPath("//iframe[@id='braintree-hosted-field-number']"));
            findElement(cardNumber).SendKeys("4189813968238783");
            switchToDefaultContent();
            return this;
        }

        public TS_CheckoutPage setCardExpMonth()
        {
            //reporter.info("Set Card Exeration Month: 09");
            switchToFrame(By.XPath("//iframe[@id='braintree-hosted-field-expirationMonth']"));
            findElement(cardExpMonth).SendKeys("09");
            switchToDefaultContent();
            return this;
        }

        public TS_CheckoutPage setCardExpYear()
        {
            //reporter.info("Set Card Exeration Year: 20");
            switchToFrame(By.XPath("//iframe[@id='braintree-hosted-field-expirationYear']"));
            findElement(cardExpYear).SendKeys("20");
            switchToDefaultContent();
            return this;
        }

        public TS_CheckoutPage setCardCVV()
        {
            //reporter.info("Set Card CVV: 210");
            switchToFrame(By.XPath("//iframe[@id='braintree-hosted-field-cvv']"));
            findElement(cardCVV).SendKeys("210");
            switchToDefaultContent();
            return this;
        }

        public TS_CheckoutPage populateAllCheckoutFields(UserEntity user)
        {
            this.setEmail(user.Email)
                    .setFirstName(user.Firstname)
                    .setLastName(user.Lastname)
                    .setStreet(user.Street)
                    .setStreet2("12")
                    .setCity(user.City)
                    .selectRegion(user.State)
                    .setPostcode(user.Zipcode)
                    .setPhone(user.Phone);
            return this;
        }

        public TS_CheckoutPage populateSpippingInfo(string state, string zip)
        {
            this.setPostcode(zip)
                .selectRegion(state);
            waitForPageToLoad();
            return this;
        }

        public TS_CheckoutPage payWithCard()
        {
            setCardNumber();
            setCardExpMonth();
            setCardExpYear();
            setCardCVV();
            return this;
        }
    }
}
