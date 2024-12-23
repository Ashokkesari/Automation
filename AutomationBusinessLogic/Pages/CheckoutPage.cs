using UIFrameworkLayer.Utilities;
using OpenQA.Selenium;
using UIFrameworkLayer.Driver;

namespace UIBusinessLayer.Pages
{
    public class CheckoutPage : BasePage
    {
        private DriverHelper _driverHelper;
        private Framework _framework;
        public CheckoutPage(DriverHelper driverHelper)
        {
            _driverHelper = driverHelper;
            _framework = new Framework(_driverHelper);
        }

        #region Elements
        private IWebElement ButtonContinue => _driverHelper.Driver.FindElement(By.Id("continue"));
        private IWebElement ErrorValidationMessage => _driverHelper.Driver.FindElement(By.XPath("//div[@class='error-message-container error']/h3"));
        private By CheckOutTitle => By.XPath("//span[text()='Checkout: Your Information']");

        #endregion

        public void ClickOnContinueUserDetails()
        {
            _framework.ScrollToLocatedElement(_driverHelper.Driver, ButtonContinue);

            _framework.Click(ButtonContinue);

        }

        public string CaptureErrorMessage()
        {
            IWebElement elem = ErrorValidationMessage;

            return elem.Text;

        }

        public bool CheckOutPageTitleCheck()
        {
            bool isCheckOutTitle = _framework.ElementExistsCheck(_driverHelper.Driver, CheckOutTitle, 5);

            return isCheckOutTitle;
        }

    }
}
