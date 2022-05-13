using TechTalk.SpecFlow;
using NatixisAssessment.Hooks;
using NatixisAssessment.PageObjects;

namespace NatixisUI.Steps
{
    [Binding]
    public sealed class InventorySteps
    {
        private readonly InventoryPageObject _inventoryPageObject;

        public InventorySteps()
        {
            _inventoryPageObject = new InventoryPageObject(Hooks.getDriver());
        }

        [When(@"I choose the first product and click the button Add to Cart")]
        public void WhenIChooseTheFirstProductAndClickTheButtonAddToCart()
        {
            _inventoryPageObject.AddFirstProduct();
        }

        [When(@"I click to add the second product")]
        public void WhenIClickToAddTheSecondProduct()
        {
            _inventoryPageObject.AddSecondProduct();
        }

        [Then(@"the cart icon must show (.*) products")]
        public void ThenTheCartIconMustShowProducts(int number)
        {
            _inventoryPageObject.ValidateCart(number);
        }

    }
}
