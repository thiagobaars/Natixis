using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using NUnit.Framework;
using System.Threading;
using NatixisAssessment.Hooks;

namespace NatixisAssessment.PageObjects
{
    public class InventoryPageObject
    {

        private readonly IWebDriver _webDriver;

        public const int DefaultWaitInSeconds = 5;

        public InventoryPageObject(IWebDriver webDriver)
        {
            _webDriver = Hooks.Hooks.getDriver();
        }

        //Finding elements
        private IWebElement BackpackAddToCartButton => _webDriver.FindElement(By.Id("add-to-cart-sauce-labs-backpack"));
        private IWebElement BoltTShirtAddToCartButton => _webDriver.FindElement(By.Id("add-to-cart-sauce-labs-bolt-t-shirt"));
        private IWebElement CartIcon => _webDriver.FindElement(By.ClassName("shopping_cart_link"));
        private IWebElement CartNumberOfProducts => _webDriver.FindElement(By.ClassName("shopping_cart_badge"));

        public void AddFirstProduct()
        {
            BackpackAddToCartButton.Click();
        }

        public void AddSecondProduct()
        {
            BoltTShirtAddToCartButton.Click();
        }

        public void ClickCart()
        {
            CartIcon.Click();
        }

        public void ValidateCart(int number)
        {
            Assert.AreEqual(int.Parse(CartNumberOfProducts.Text), number);
        }
    }
}
