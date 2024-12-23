using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace UIFrameworkLayer.Utilities
{
    public static class WaitUtil
    {
        public static void SetImplicitWait(IWebDriver driver, int timeoutInSeconds)
        {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(timeoutInSeconds);
        }

        public static IWebElement WaitForElementClickable(IWebDriver driver, IWebElement element, int timeoutInSeconds)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds));
            return wait.Until(ExpectedConditions.ElementToBeClickable(element));
        }

        public static IWebElement WaitForElementPresence(IWebDriver driver, By locator, int timeoutInSeconds)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds));
            return wait.Until(ExpectedConditions.ElementIsVisible(locator));
        }

        public static bool WaitForTextToBePresent(IWebDriver driver, IWebElement element, string text, int timeoutInSeconds)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds));
            return wait.Until(ExpectedConditions.TextToBePresentInElement(element, text));
        }

        public static IWebElement? WaitForElementWithFluentWait(IWebDriver driver, By locator, int timeoutInSeconds, int pollingIntervalInMillis)
        {
            DefaultWait<IWebDriver> fluentWait = new DefaultWait<IWebDriver>(driver)
            {
                Timeout = TimeSpan.FromSeconds(timeoutInSeconds),
                PollingInterval = TimeSpan.FromMilliseconds(pollingIntervalInMillis)
            };
            fluentWait.IgnoreExceptionTypes(typeof(NoSuchElementException), typeof(StaleElementReferenceException));

            return fluentWait.Until(drv =>
            {
                IWebElement element = drv.FindElement(locator);
                return element != null && element.Displayed ? element : null;
            });
        }

    }
}