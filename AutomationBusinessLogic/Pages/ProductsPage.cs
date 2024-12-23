using UIFrameworkLayer.Utilities;
using OpenQA.Selenium;
using UIFrameworkLayer.Driver;

namespace UIBusinessLayer.Pages
{
    public class ProductsPage : BasePage
    {
        private DriverHelper _driverHelper;
        private Framework _framework;

        public ProductsPage(DriverHelper driverHelper)
        {
            _driverHelper = driverHelper;
            _framework = new Framework(_driverHelper);
        }

        #region Elements

        private IList<IWebElement> Listitems => _driverHelper.Driver.FindElements(By.XPath("//div[@class='inventory_list']/div"));
        private IWebElement LinkShoppingCart => _driverHelper.Driver.FindElement(By.XPath("//a[@class='shopping_cart_link']"));
        private IWebElement SpanItemCountFromShoppingCart => _driverHelper.Driver.FindElement(By.XPath("//a[@class='shopping_cart_link']/span"));

        #endregion

        #region Actions

        public List<int> FilterItemsByPrice(string price)
        {
            List<int> items = new List<int>();
            if (Listitems.Count > 0)
            {
                for (int i = 0; i < Listitems.Count; i++)
                {
                    double Actualprice = Helper.ConvertStringToDouble(GetTheInventoryItemPrice(i));

                    double ItemPriceValue = Helper.ConvertStringToDouble(price);

                    if (Actualprice < ItemPriceValue)
                    {
                        items.Add(i);

                    }
                }
            }
            else
            {
                throw new Exception("There are no items present");
            }

            return items;
        }

        public string GetTheInventoryItemPrice(int itemIndex)
        {
            IWebElement itemPriceElement = _driverHelper.Driver.FindElement(By.XPath("//a[@id='item_" + itemIndex + "_title_link']/parent::div/following-sibling::div[@class='pricebar']/div"));

            return itemPriceElement.Text;
        }

        public void AddItemToCart(List<int> itemIndex)
        {
            for (int i = 0; i < itemIndex.Count; i++)
            {
                IWebElement btnAddToCart = _driverHelper.Driver.FindElement(By.XPath("//a[@id='item_" + itemIndex[i] + "_title_link']/parent::div/following-sibling::div[@class='pricebar']/button"));
                _framework.Click(btnAddToCart);
            }

        }

        public int GetCountFromShoppingCart()
        {
            _framework.ScrollToLocatedElement(_driverHelper.Driver, LinkShoppingCart);
            int count = -1;
            IWebElement elem = SpanItemCountFromShoppingCart;
            bool value = int.TryParse(elem.Text, out count);
            return count;
        }

        public void ClickShoppingCart()
        {

            LinkShoppingCart.Click();

        }

        #endregion
    }
}
