using OpenQA.Selenium;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using AventStack.ExtentReports.Gherkin.Model;
using UIFrameworkLayer.Driver;
using UIFrameworkLayer.Utilities;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;

namespace UITestLayer.Hooks
{
    [Binding]
    public sealed class Hooks
    {
        private DriverHelper _driverHelper;
        private Framework _framework;         
        private ScenarioContext _scenarioContext;
        private static ExtentTest? feature;
        private static ExtentTest? scenario;
        private static ExtentReports? extentReports;

        public Hooks(ScenarioContext context, DriverHelper driverHelper)
        {
            _scenarioContext = context;
            _driverHelper = driverHelper;
            _framework = new Framework(driverHelper);
        }

        [BeforeTestRun]
        public static void BeforeTestRun()
        {
            
            extentReports = new ExtentReports();
            extentReports.AttachReporter(new ExtentSparkReporter($@"C:\Users\ashokreddy_kesari\Desktop\Screenshots\log\Report.html"));
        }

        [BeforeFeature]
        public static void BeforeFeature(FeatureContext featureContext)
        {
            if (featureContext != null)
            {
                feature = extentReports?.CreateTest<Feature>(featureContext.FeatureInfo.Title, featureContext.FeatureInfo.Description);
            }
        }

  //      [BeforeScenario("Positive")]
        [BeforeScenario]
        public void BeforeScenario(ScenarioContext scenarioContext)
        {
            if (scenarioContext != null)
            {
                _scenarioContext = scenarioContext;
                scenario = feature?.CreateNode<Scenario>(_scenarioContext.ScenarioInfo.Title, _scenarioContext.ScenarioInfo.Description);

                var browser = _scenarioContext.ScenarioInfo.Arguments["Browser"].ToString();

                switch (browser.ToLower())
                {
                    case "chrome":
                        GetDriver("chrome");
                        break;
                    case "edge":
                        GetDriver("edge");
                        break;
                    case "firefox":
                        GetDriver("firefox");
                        break;
                    default:
                        throw new Exception("Please choose browser : chrome or Edge, or Firefox only");
                }

                _driverHelper.Driver.Manage().Window.Maximize();
                _scenarioContext.Set(_driverHelper.Driver, "Driver");
            }


        }

        [AfterStep]
        public void AfterStep()
        {
            ScenarioBlock scenarioBlock = _scenarioContext.CurrentScenarioBlock;

            switch (scenarioBlock)
            {
                case ScenarioBlock.Given:
                    CreateNode<Given>();
                    break;
                case ScenarioBlock.When:
                    CreateNode<When>();
                    break;
                case ScenarioBlock.Then:
                    CreateNode<Then>();
                    break;
                default:
                    CreateNode<And>();
                    break;
            }
        }

        [AfterScenario]
        public void AfterScenario()
        {
            // DriverUtil.QuitDriver();

            if (_driverHelper.Driver!= null)
            {
                _driverHelper.Driver.Quit();
                _driverHelper.Driver = null;
            }

        }
      
        [AfterTestRun]
        public static void TearDownReport()
        {
            extentReports?.Flush();
        }

        public void CreateNode<T>() where T : IGherkinFormatterModel
        {
            if (_scenarioContext.TestError != null)
            {
                string fileName = @"C:\Users\ashokreddy_kesari\Desktop\Screenshots\log" + _scenarioContext.ScenarioInfo.Title.ToString() + "_" + Helper.RandomString(8) + ".png";
                Framework.TakeScreenShot(_driverHelper.Driver, fileName);               
                scenario?.CreateNode<T>(_scenarioContext.StepContext.StepInfo.Text).Fail(_scenarioContext.TestError.Message + "\n" + _scenarioContext.TestError.StackTrace).AddScreenCaptureFromPath(fileName);
            }
            else
            {
                scenario?.CreateNode<T>(_scenarioContext.StepContext.StepInfo.Text);
            }
        }

        public IWebDriver GetDriver(string browserType)
        {

            _driverHelper.Driver = browserType.ToLower() switch
            {
                "chrome" => new ChromeDriver(),
                "firefox" => new FirefoxDriver(),
                "edge" => new EdgeDriver(),
                _ => throw new ArgumentException("Unspported browser Type"),
            };
            return _driverHelper.Driver;

        }
    }
}