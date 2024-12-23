using FluentAssertions;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
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
    public class ElementInteractions : IElementInteractions
    {
        private readonly DriverHelper _driverHelper;

        public ElementInteractions(DriverHelper driverHelper)
        {
            _driverHelper = driverHelper;
        }

        public void Click(IWebElement element)
        {
            if (element.Enabled)
            {
                element.Click();
            }
            else
            {
                throw new Exception("Element not enabled to click");
            }
        }

        public void InputText(IWebElement element, string? text)
        {
            element.SendKeys(text);
            Thread.Sleep(1000);
            text.Should().Be(element.GetAttribute("value"));
        }

        public void DragAndDrop(IWebElement source, IWebElement destination)
        {
            Actions actions = new Actions(_driverHelper.Driver);
            actions.DragAndDrop(source, destination).Build().Perform();
            Thread.Sleep(1000);
        }

    }
}
