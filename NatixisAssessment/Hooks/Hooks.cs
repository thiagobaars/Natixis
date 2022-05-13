using TechTalk.SpecFlow;

using OpenQA.Selenium;
using NatixisAssessment.Drivers;

namespace NatixisAssessment.Hooks
{

    [Binding]
    public class Hooks : BrowserDriver
    {
        private static IWebDriver driver;

        [BeforeFeature("UI")]
        public static void Initialize()
        {
            driver = startDriver();
        }

        [AfterFeature("UI")]
        public static void TearDown()
        {
            driver.Quit();
        }

        public static IWebDriver getDriver()
        {
            return driver;
        }

    }
}