using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using UIFrameworkLayer.Driver;
using FluentAssertions;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using UIFrameworkLayer.Helpers;

namespace UIFrameworkLayer.Utilities
{
    public class Framework
    {
        private DriverHelper _driverHelper;
        public Framework(DriverHelper driverHelper)
        {
            _driverHelper = driverHelper;
        }

        public void WaitForBusyIndicatorToLoad(int timeoutInSeconds = 10)
        {
            bool isPageLoaded = false;
            while (timeoutInSeconds > 0)
            {
                try
                {
                    _driverHelper.Driver.FindElement(By.CssSelector("html[aria-busy=true]"));
                    isPageLoaded = false;
                    Thread.Sleep(1000);
                    timeoutInSeconds--;
                }
                catch
                {
                    isPageLoaded = true;
                    break;
                }
            }
            if (!isPageLoaded)
                throw new Exception($"Failed to load busy indictor in {10} seconds");
        }

        public bool IsElementClickable(IWebElement element)
        {
            bool isPresent;
            try
            {
                WaitUtil.WaitForElementClickable(_driverHelper.Driver, element, 10);
                isPresent = true;
            }
            catch
            {
                isPresent = false;
            }
            return isPresent;
        }

        public void RetryClick(IWebElement element, int timeoutInSeconds = 10)
        {
            try
            {
                element.Click();
            }
            catch (ElementClickInterceptedException)
            {
                try
                {
                    element = WaitUtil.WaitForElementClickable(_driverHelper.Driver, element, timeoutInSeconds);
                    element.Click();
                }
                catch (Exception)
                {
                    throw;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void InputText(IWebElement element, string? text)
        {
            element.SendKeys(text);
            Thread.Sleep(1000);
            text.Should().Be(element.GetAttribute("value"));           
        }

        public void GetUsernameAndPasswordList(List<string> textData, out string? username, out string? password)
        {
            username = textData.FirstOrDefault()?.Split(':').LastOrDefault();
            password = textData.LastOrDefault()?.Split(':').LastOrDefault();
        }

        public void WaitForTextToBeVisible(IWebElement element, string text)
        {
            bool areEqual = false;
            int i = 0;

            while (i < 3)
            {
                areEqual = WaitUtil.WaitForTextToBePresent(_driverHelper.Driver, element, text, 10);
                if (areEqual)
                {
                    break;
                }
                else
                {
                    i++;
                }
            }

            if (!areEqual)
                throw new Exception($"Actual and Expected strings are not equal: {element.Text}, {text}");
        }

        public void ClickByJavaScriptExecutor(By locator)
        {
            IWebElement? ele = WaitUtil.WaitForElementWithFluentWait(_driverHelper.Driver, locator, 10, 100);
            IJavaScriptExecutor executor = (IJavaScriptExecutor)_driverHelper.Driver;
            executor.ExecuteScript("arguments[0].click();", ele);
        }

        public static void TakeScreenShot(IWebDriver _driverHelper, string fileName)
        {
            Screenshot screenshot = ((ITakesScreenshot)_driverHelper).GetScreenshot();
            screenshot.SaveAsFile(fileName);
        }

        public void VerifyTextOnAlert(string alertText)
        {
            IAlert alert = _driverHelper.Driver.SwitchTo().Alert();

            alert.Text.Should().Be(alertText);
        }

        public void ClickButtonOnAlert(string button)
        {
            IAlert alert = _driverHelper.Driver.SwitchTo().Alert();
            if (button.ToLower().Equals("ok"))
                alert.Accept();
            else
                alert.Dismiss();
        }

        public void EnterValueInAlertInputField(string value)
        {
            IAlert alert = _driverHelper.Driver.SwitchTo().Alert();
            alert.SendKeys(value);
        }

        public void AssertAlertDialogClosed()
        {
            try
            {
                _driverHelper.Driver.SwitchTo().Alert();
            }
            catch 
            {
                Console.WriteLine("Dialog Closed");
            }
        }

        public void SwitchToFrame(IWebElement element)
        {
            _driverHelper.Driver.SwitchTo().Frame(element);
        }

        public void SwitchToDefaultContent()
        {
            _driverHelper.Driver.SwitchTo().DefaultContent();
        }

        public void SwitchToParentFrame()
        {
            _driverHelper.Driver.SwitchTo().ParentFrame();
        }

        public void DragAndDrop(IWebElement source, IWebElement destination)
        {
            Actions actions = new Actions(_driverHelper.Driver);
            actions.DragAndDrop(source, destination).Build().Perform();
            Thread.Sleep(1000);
        }

        public void PressKeyboardShorcutControlK()
        {
            new Actions(_driverHelper.Driver)
                .KeyDown(Keys.Control)
                .SendKeys("k")
                .KeyUp(Keys.Control)
                .Perform();
        }

        public void ScrollToLocatedElement(IWebDriver _driverHelper, IWebElement elem)
        {
            IJavaScriptExecutor javaScriptExecutor = (IJavaScriptExecutor)_driverHelper;
            javaScriptExecutor.ExecuteScript("arguments[0].scrollIntoView(true);", elem);
        }

        public bool ElementExistsCheck(IWebDriver _driverHelper, By locator, int seconds)
        {

            WebDriverWait waitElement = new WebDriverWait(_driverHelper, TimeSpan.FromSeconds(seconds));

            try
            {
                if (waitElement.Until(ExpectedConditions.ElementExists(locator)) != null)
                {

                    return true;
                }

            }
            catch (WebDriverTimeoutException ex)
            {
                Console.WriteLine(ex.Message);
            }

            return false;
        }

        public void Click(IWebElement element)
        {
           if(IsElementClickable(element))
            {
                element.Click();
            }
            else
            {
                throw new Exception("Element not clickable");
            }
        }
    }
}
