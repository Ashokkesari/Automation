using UIFrameworkLayer.Driver;
using UIBusinessLayer.Pages;

namespace UITestLayer.StepDefinitions
{

    [Binding]
    public class SwagLabsLoginStepDefinitions
    {
        private ScenarioContext _scenarioContext;
        private readonly LoginPage loginPage;

        public SwagLabsLoginStepDefinitions(ScenarioContext context, DriverHelper driverHelper) 
        {
            _scenarioContext = context;
           loginPage = new LoginPage(driverHelper);
        }


        [When(@"the user navigates to SwagLabs login page")]
        public void WhenTheUserNavigatesToSwagLabsLoginPage()
        {
            loginPage.NavigateToSwagLabs();
        }


        [Given(@"the user navigates to SwagLabs login page")]
        public void GivenTheUserNavigatesToSwagLabsLoginPage()
        {
            loginPage.NavigateToSwagLabs();
        }


        [When(@"the user enters the Username '([^']*)'")]
        public void WhenTheUserEntersTheUsername(string username)
        {
            loginPage.EnterUserName(username);
        }

        [Then(@"the user enters the Password '([^']*)'")]
        public void ThenTheUserEntersThePassword(string password)
        {
            loginPage.EnterPassword(password);
        }

        [Then(@"the user clicks Sign in button")]
        public void ThenTheUserClicksSignInButton()
        {
            loginPage.ClickLogin();
        }

        [Then(@"the user verifies the successfull login")]
        public void ThenTheUserVerifiesTheSuccessfullLogin()
        {
            loginPage.VerifyLoginIsSuccessful();
        }

        [Then(@"the user should an error message")]
        public void ThenTheUserShouldAnErrorMessage()
        {
           loginPage.VerifyInvalidLogin();
        }

    }
}
