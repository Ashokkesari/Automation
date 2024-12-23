using OpenQA.Selenium;
using UIFrameworkLayer.Driver;
using UIFrameworkLayer.Utilities;

namespace UIBusinessLayer.Pages
{
    public class CartPage : BasePage
    {
        private DriverHelper _driverHelper;
        private Framework _framework;
        public CartPage(DriverHelper driverHelper)
        {
            _driverHelper = driverHelper;
            _framework = new Framework(_driverHelper);
        }


        #region Elements
        private IWebElement btnCheckOut => _driverHelper.Driver.FindElement(By.Id("checkout"));
      
        private By spanTxtYourCart => By.XPath("//span[text()='Your Cart']");

        #endregion


        public bool CheckCartPageLanding()
        {
            bool landedToCartPage = _framework.ElementExistsCheck(_driverHelper.Driver, spanTxtYourCart, 5);
            Log.Debug("Cart page landed");
            return landedToCartPage;
            
        }

        public void PerformCheckOut()
        {
           
             _framework.Click(btnCheckOut);
        }

       
    }
}
