using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UIFrameworkLayer.Helpers
{
    public interface IElementInteractions
    {
        void Click(IWebElement element);
        void InputText(IWebElement element, string text);
        void DragAndDrop(IWebElement source, IWebElement destination);
    }
}
