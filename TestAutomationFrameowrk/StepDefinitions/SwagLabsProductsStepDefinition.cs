using UIFrameworkLayer.Driver;
using UIBusinessLayer.Pages;

namespace UITestLayer.StepDefinitions
{
    [Binding]
    public class SwagLabsProductsStepDefinition
    {

        private readonly int ItemsCount;
        private ScenarioContext _scenarioContext;
        private ProductsPage productsPage;
        public SwagLabsProductsStepDefinition(ScenarioContext context, DriverHelper driverHelper)
        {

            _scenarioContext = context;
            productsPage = new ProductsPage(driverHelper);
        }

        [When(@"Add the items to cart which has less than ""([^""]*)""")]
        public void WhenAddTheItemsToCartWhichHasLessThan(string costPrice)
        {
         
            List<int> items = productsPage.FilterItemsByPrice(costPrice);
            productsPage.AddItemToCart(items);
            
        }

        [Then(@"Landed to shopping cart page")]
        public void ThenLandedToShoppingCartPage()
        {
            int expectedCount = productsPage.GetCountFromShoppingCart();
            int actualCount = ItemsCount;
            AssertionOptions.Equals(expectedCount, actualCount);
        }

        [Then(@"Added item count should match with shopping cart item count")]
        public void ThenAddedItemCountShouldMatchWithShoppingCartItemCount()
        {
           productsPage.ClickShoppingCart();
        }


    }
}
