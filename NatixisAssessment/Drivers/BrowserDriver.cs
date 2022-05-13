using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;

namespace NatixisAssessment.Drivers
{
    public class BrowserDriver
    {

        private static IWebDriver driver;

        public static IWebDriver startDriver()
        {
            new DriverManager().SetUpDriver(new ChromeConfig());
            var chromeDriverService = ChromeDriverService.CreateDefaultService();
            var chromeOptions = new ChromeOptions();
            driver = new ChromeDriver(chromeDriverService, chromeOptions);
            driver.Manage().Window.Maximize();
            return driver;
        }
    }
}