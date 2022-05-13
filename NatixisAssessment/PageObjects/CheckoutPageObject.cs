using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using NUnit.Framework;
using System.Threading;
using NatixisAssessment.Hooks;

namespace NatixisAssessment.PageObjects
{
    public class CheckoutPageObject
    {

        private readonly IWebDriver _webDriver;
        public const int DefaultWaitInSeconds = 5;

        public CheckoutPageObject(IWebDriver webDriver)
        {
            _webDriver = Hooks.Hooks.getDriver();
        }

        //Finding elements
        private IWebElement FirstNameField => _webDriver.FindElement(By.Id("first-name"));
        private IWebElement LastNameField => _webDriver.FindElement(By.Id("last-name"));
        private IWebElement PostalCodeField => _webDriver.FindElement(By.Id("postal-code"));
        private IWebElement ContinueButton => _webDriver.FindElement(By.Id("continue"));
        private IWebElement FinishButton => _webDriver.FindElement(By.Id("finish"));
        private IWebElement Message => _webDriver.FindElement(By.XPath("//*[@class='complete-header' and text()='THANK YOU FOR YOUR ORDER']"));


        public void FillFirstName(string FirstName)
        {
            FirstNameField.Clear();
            FirstNameField.SendKeys(FirstName);
        }

        public void FillLastaName(string LastName)
        {
            LastNameField.Clear();
            LastNameField.SendKeys(LastName);
        }
        public void FillPostalCode(string PostalCode)
        {
            PostalCodeField.Clear();
            PostalCodeField.SendKeys(PostalCode);
        }

        public void ClickContinueButton()
        {
            ContinueButton.Click();
        }

        public void VerifySumOfItens()
        {
            string FirstItemPrice = _webDriver.FindElement(By.XPath("//div[@class='cart_item'][1]//div[@class='inventory_item_price']")).Text.Replace("$", "");
            string SecondItemPrice = _webDriver.FindElement(By.XPath("//div[@class='cart_item'][2]//div[@class='inventory_item_price']")).Text.Replace("$", "");

            string ItemTotal = _webDriver.FindElement(By.ClassName("summary_subtotal_label")).Text.Replace("Item total: $", "");
            string Tax = _webDriver.FindElement(By.ClassName("summary_tax_label")).Text.Replace("Tax: $", "");
            string Total = _webDriver.FindElement(By.ClassName("summary_total_label")).Text.Replace("Total: $", "");

            Assert.AreEqual(float.Parse(FirstItemPrice) +
                            float.Parse(SecondItemPrice),
                            float.Parse(ItemTotal));

            Assert.AreEqual(float.Parse(FirstItemPrice) +
                            float.Parse(SecondItemPrice) +
                            float.Parse(Tax),
                            float.Parse(Total));

        }

        public void ClickFinishButton()
        {
            FinishButton.Click();
        }

        public void VerifyMessageIsDisplayed(string message)
        {
            Assert.True(Message.Displayed, "Something wrong with the order.");
        }
    }
}
