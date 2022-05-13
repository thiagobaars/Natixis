using System;
using TechTalk.SpecFlow;
using System.Threading;
using NatixisAssessment.Hooks;
using NatixisAssessment.PageObjects;

namespace NatixisAssessment.Steps
{
    [Binding]
    public sealed class CheckoutSteps
    {
        private readonly CheckoutPageObject _checkoutPageObject;
        private readonly CartPageObject _cartPageObject;

        public CheckoutSteps()
        {
            _checkoutPageObject = new CheckoutPageObject(Hooks.Hooks.getDriver());
            _cartPageObject = new CartPageObject(Hooks.Hooks.getDriver());
        }

        [Given(@"I click the Checkout button")]
        public void GivenIClickTheCheckoutButton()
        {
            _cartPageObject.ClickCheckoutButton();
        }

        [When(@"I fill the the fields First, Last Name and Zip Code with the values '([^']*)', '([^']*)' and '([^']*)'")]
        public void WhenIFillTheTheFieldsFirstLastNameAndZipCodeWithTheValuesAnd(string FirstName, string LastName, string PostalCode)
        {
            _checkoutPageObject.FillFirstName(FirstName);
            _checkoutPageObject.FillLastaName(LastName);
            _checkoutPageObject.FillPostalCode(PostalCode);
        }

        [When(@"I click the Continue button")]
        public void WhenIClickTheContinueButton()
        {
            _checkoutPageObject.ClickContinueButton();
        }

        [Then(@"I verify the sum of the items prices, tax and total")]
        public void ThenIVerifyTheSumOfTheItemsPricesTaxAndTotal()
        {
            _checkoutPageObject.VerifySumOfItens();
        }

        [Then(@"I click in the Finish button")]
        public void ThenIClickInTheFinishButton()
        {
            _checkoutPageObject.ClickFinishButton();
        }

        [Then(@"I verify if the message '([^']*)' is displayed")]
        public void ThenIVerifyIfTheMessageIsDisplayed(string message)
        {
            _checkoutPageObject.VerifyMessageIsDisplayed(message);
        }


    }
}
