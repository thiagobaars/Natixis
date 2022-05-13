
using TechTalk.SpecFlow;
using NatixisAssessment.PageObjects;

namespace NatixisAssessment.Steps
{
    [Binding]
    public sealed class CartSteps
    {
        private readonly InventoryPageObject _inventoryPageObject;
        private readonly CartPageObject _cartPageObject;

        public CartSteps()
        {
            _inventoryPageObject = new InventoryPageObject(Hooks.Hooks.getDriver());
            _cartPageObject = new CartPageObject(Hooks.Hooks.getDriver());
        }

        [Given(@"I click the cart icon")]
        public void GivenIClickTheCartIcon()
        {
            _inventoryPageObject.ClickCart();
        }

        [Then(@"the selected itens must appear in the page")]
        public void ThenTheSelectedItensMustAppearInThePageWithTheirPrices()
        {
            _cartPageObject.VerifyItems();
        }

    }
}
