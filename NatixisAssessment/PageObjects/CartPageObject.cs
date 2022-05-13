using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using NUnit.Framework;
using NatixisAssessment.Hooks;

namespace NatixisAssessment.PageObjects
{
    public class CartPageObject
    {

        private readonly IWebDriver _webDriver;
        public const int DefaultWaitInSeconds = 5;

        public CartPageObject(IWebDriver webDriver)
        {
            _webDriver = Hooks.Hooks.getDriver();
        }

        //Finding elements
        private IWebElement FirstItem => _webDriver.FindElement(By.XPath("//div[@class='cart_item'][1]"));
        private IWebElement SecondItem => _webDriver.FindElement(By.XPath("//div[@class='cart_item'][2]"));
        private IWebElement CheckoutButton => _webDriver.FindElement(By.Id("checkout"));


        public void VerifyItems()
        {
            Assert.IsTrue(FirstItem.Displayed, "Some of the items are missing");
            Assert.IsTrue(SecondItem.Displayed, "Some of the items are missing");
        }

        public void ClickCheckoutButton()
        {
            CheckoutButton.Click();
        }
    }
}
