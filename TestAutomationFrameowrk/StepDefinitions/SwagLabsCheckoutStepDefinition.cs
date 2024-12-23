using UIFrameworkLayer.Driver;
using NUnit.Framework;
using UIBusinessLayer.Pages;

namespace UITestLayer.StepDefinitions
{
    [Binding]
    public class SwagLabsCheckoutStepDefinition
    {
        private ScenarioContext _scenarioContext;
        private CheckoutPage checkoutPage;
        public SwagLabsCheckoutStepDefinition(ScenarioContext context, DriverHelper driverHelper)
        {
            _scenarioContext = context;
            checkoutPage = new CheckoutPage(driverHelper);
        }

        [Then(@"checkout user page")]
        public void ThenCheckoutUserPage()
        {
            checkoutPage.CheckOutPageTitleCheck();
        }

        [Then(@"perform continue")]
        public void ThenPerformContinue()
        {
            checkoutPage.ClickOnContinueUserDetails();
        }

        [Then(@"should see the error message ""([^""]*)""")]
        public void ThenShouldSeeTheErrorMessage(string expectedMessage)
        {

            string actualMessage = checkoutPage.CaptureErrorMessage();
            Assert.AreEqual(expectedMessage, actualMessage);
            
        }

        [Then(@"navigate successfully to checkout page")]
        public void ThenNavigateSuccessfullyToCheckoutPage()
        {
            checkoutPage.CheckOutPageTitleCheck();
        }



    }
}
