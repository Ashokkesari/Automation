using UIFrameworkLayer.Utilities;
using FluentAssertions;
using OpenQA.Selenium;
using UIFrameworkLayer.Driver;
using NUnit.Framework;
using UIFrameworkLayer.GenericHelpers;

namespace UIBusinessLayer.Pages
{
    public class LoginPage : BasePage
    {

        private DriverHelper _driverHelper;
        private Framework _framework;
        private Navigations navigations;
        private ElementInteractions elementInteractions;
        public LoginPage(DriverHelper driverHelper)
        {
            _driverHelper = driverHelper;
            _framework = new Framework(_driverHelper);
            navigations = new Navigations(_driverHelper);
            elementInteractions = new ElementInteractions(_driverHelper);

        }

        #region LoginPageElements

        private IWebElement UserName => _driverHelper.Driver.FindElement(By.XPath("//input[@id='user-name']"));
        private IWebElement Password => _driverHelper.Driver.FindElement(By.XPath("//input[@id='password']"));
        private IWebElement Login => _driverHelper.Driver.FindElement(By.XPath("//input[@id='login-button']"));
        private IWebElement LoginLogo => _driverHelper.Driver.FindElement(By.XPath("//div[@class='login_logo']"));
        private IWebElement Usernames => _driverHelper.Driver.FindElement(By.XPath("//div[@id='login_credentials']"));
        private IWebElement ProductsText => _driverHelper.Driver.FindElement(By.XPath("//span[@class='title' and text()='Products']"));
        private IWebElement InvalidLoginErrorMessage => _driverHelper.Driver.FindElement(By.XPath("//h3[@data-test='error']"));


        #endregion

        #region Actions

        public void NavigateToSwagLabs()
        {
            string url = Helper.GetDataFromJsonFile("Url");
            Log.Debug($"Navigating to url : {url}");
            navigations.NavigateTo(url);
            WaitUtil.WaitForTextToBePresent(_driverHelper.Driver, LoginLogo, "Swag Labs", 10);
            Log.Debug($"Login page displayed");

        }

        public void EnterUserName(string username)
        {
            Log.Debug($"Entering Username: {username}");
            elementInteractions.InputText(UserName, username);

        }

        public void EnterPassword(string password)
        {
            Log.Debug($"Entering Password: {password}");
            elementInteractions.InputText(Password, password);
        }

        public void ClickLogin()
        {
            elementInteractions.Click(Login);
        }

        public void VerifyLoginIsSuccessful()
        {
            string productsText = ProductsText.Text;
            productsText.Should().Be("Products");
        }

        public void GetAllCredentials()
        {

            string users = Usernames.Text;


            string[] lines = users.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
            List<string> usernames = new List<string>();
            for (int i = 1; i < lines.Length; i++)
            {
                usernames.Add(lines[i].Trim());
            }

            Dictionary<string, string> elementTexts = new Dictionary<string, string>();


            foreach (string user in usernames)
            {
                switch (user)
                {
                    case "standard_user":
                        elementTexts.Add("standard", user);
                        break;

                    case "locked_out_user":
                        elementTexts.Add("locked_out", user);
                        break;

                    case "problem_user":
                        elementTexts.Add("problem_user", user);
                        break;

                    case "performance_glitch_user":
                        elementTexts.Add("performance_glitch", user);
                        break;

                    case "error_user":
                        elementTexts.Add("error_user", user);
                        break;

                    case "visual_user":
                        elementTexts.Add("visual_user", user);
                        break;
                }

            }

        }     

        public void VerifyInvalidLogin()
        {
            Assert.True(InvalidLoginErrorMessage.Displayed);
        }

        #endregion
    }
}
