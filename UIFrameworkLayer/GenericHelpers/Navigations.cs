using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UIFrameworkLayer.Driver;
using UIFrameworkLayer.Helpers;
using UIFrameworkLayer.Utilities;

namespace UIFrameworkLayer.GenericHelpers
{
    public class Navigations : INavigator
    {
        private DriverHelper _driverHelper;

        public Navigations(DriverHelper driverHelper)
        {
            _driverHelper = driverHelper;
        }


        public void NavigateTo(string url)
        {
            _driverHelper.Driver.Navigate().GoToUrl(url);
            WaitUtil.SetImplicitWait(_driverHelper.Driver, 10);
        }

        public void NavigateBack()
        {
            _driverHelper.Driver.Navigate().Back();
        }

        public void SwitchToTab()
        {
            _driverHelper.Driver.SwitchTo().Window(DriverUtil.Driver.WindowHandles[1]);
        }
    }
}
