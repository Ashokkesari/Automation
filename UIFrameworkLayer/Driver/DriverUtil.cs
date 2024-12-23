using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;

namespace UIFrameworkLayer.Driver
{
    public class DriverUtil
    {
        private static readonly ThreadLocal<IWebDriver> _driver = new ThreadLocal<IWebDriver>();
        private static readonly object lockObject = new object();

        public static IWebDriver Driver
        {
            get
            {
                if (_driver.Value == null)
                {
                    throw new InvalidOperationException("WebDriver not initialized. Call GetDriver with appropriate browser type.");
                }
                return _driver.Value;
            }
        }

        public static IWebDriver GetDriver(string browserType)
        {
            // Locking to ensure that only one thread
            // can initialize the WebDriver at a time

            lock (lockObject)
            {
                if (_driver.Value == null)
                {
                    _driver.Value = CreateDriverInstance(browserType);
                }
                return _driver.Value;
            }
        }

        private static IWebDriver CreateDriverInstance(string browserType)
        {
            switch (browserType.ToLower())
            {
                case "chrome":
                    return new ChromeDriver();
                case "firefox":
                    return new FirefoxDriver();
                case "edge":
                    return new EdgeDriver();
                default:
                    throw new ArgumentException("Unsupported browser type");
            }
        }

        public static void QuitDriver()
        {
            lock (lockObject)
            {
                if (_driver.Value != null)
                {
                    _driver.Value.Quit();
                    _driver.Value = null;
                }
            }
        }
    }
}
