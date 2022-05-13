using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using NUnit.Framework;
using NatixisAssessment.Hooks;

namespace NatixisAssessment.PageObjects
{
    public class LoginPageObject
    {
        private const string Url = "https://www.saucedemo.com/";

        private readonly IWebDriver _webDriver;
        public const int DefaultWaitInSeconds = 5;

        public LoginPageObject(IWebDriver webDriver)
        {
            _webDriver = Hooks.Hooks.getDriver();
        }

        //Finding elements
        private IWebElement Username => _webDriver.FindElement(By.Id("user-name"));
        private IWebElement Password => _webDriver.FindElement(By.Id("password"));
        private IWebElement LoginButton => _webDriver.FindElement(By.Id("login-button"));
        private IWebElement InventoryContainer => _webDriver.FindElement(By.Id("inventory_container"));

        public void EnterUsername(string username)
        {
            Username.Clear();
            Username.SendKeys(username);
        }

        public void EnterPassword(string password)
        {
            Password.Clear();
            Password.SendKeys(password);
        }

        public void ClickLogin()
        {
            LoginButton.Click();
        }

        public void ValidarLogin()
        {
            Assert.True(InventoryContainer.Displayed, "Login Failure");
        }

        public void AcessarUrl()
        {
            _webDriver.Navigate().GoToUrl(Url);
        }
    }
}
