using UIFrameworkLayer.Driver;
using NUnit.Framework;
using UIBusinessLayer.Pages;

namespace UITestLayer.StepDefinitions
{
    [Binding]
    public class SwagLabsCartStepDefinition
    {
       
        private ScenarioContext _scenarioContext;
        private readonly CartPage cartPage;
       
        public SwagLabsCartStepDefinition(ScenarioContext context, DriverHelper driverHelper)
        {
            _scenarioContext = context;
            cartPage = new CartPage(driverHelper);
        }

        [Then(@"shopping cart page")]
        public void ThenShoppingCartPage()
        {

            Assert.True(cartPage.CheckCartPageLanding());
           
        }

        [Then(@"checkout the item")]
        public void ThenCheckoutTheItem()
        {
            cartPage.PerformCheckOut();
        }
       

    }
}
