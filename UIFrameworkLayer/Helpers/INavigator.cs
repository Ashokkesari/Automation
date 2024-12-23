using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UIFrameworkLayer.Driver;
using UIFrameworkLayer.Utilities;

namespace UIFrameworkLayer.Helpers
{
    public interface INavigator
    {
        void NavigateTo(string url);
        void NavigateBack();
        void SwitchToTab();
    }
}
