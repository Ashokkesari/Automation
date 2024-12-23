using AventStack.ExtentReports;
using AventStack.ExtentReports.Gherkin.Model;
using AventStack.ExtentReports.Reporter;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Infrastructure;

namespace RestSharpTestLayer.Hooks
{
    [Binding]
    public sealed class Hooks
    {
        private ScenarioContext _scenarioContext;
        private static ISpecFlowOutputHelper? _outputHelper;
        private static ExtentTest? feature;
        private static ExtentTest? scenario;
        private static ExtentReports? extentReports;

        public Hooks(ScenarioContext context, ISpecFlowOutputHelper outputHelper)
        {
            _scenarioContext = context;
            _outputHelper = outputHelper;
        }

        [BeforeTestRun]
        public static void BeforeTestRun()
        {
            extentReports = new ExtentReports();
            extentReports.AttachReporter(new ExtentSparkReporter(@"C:\Users\ashokreddy_kesari\Desktop\APIScreenshots\APILog\APIlog.html"));
        }

        [BeforeFeature]
        public static void BeforeFeature(FeatureContext featureContext)
        {
            if (featureContext != null)
            {
                feature = extentReports?.CreateTest<Feature>(featureContext.FeatureInfo.Title, featureContext.FeatureInfo.Description);
            }
        }

        [BeforeScenario]
        public void BeforeScenario(ScenarioContext scenarioContext)
        {
            if (scenarioContext != null)
            {
                _scenarioContext = scenarioContext;
                scenario = feature?.CreateNode<Scenario>(_scenarioContext.ScenarioInfo.Title, _scenarioContext.ScenarioInfo.Description);
            }
        }

        [AfterScenario]
        public void AfterScenario()
        {
            _outputHelper?.WriteLine("API Tests executed");
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


        [AfterTestRun]
        public static void TearDownReport()
        {
            extentReports?.Flush();
        }

        public void CreateNode<T>() where T : IGherkinFormatterModel
        {
            if (_scenarioContext.TestError != null)
            {
              
                scenario?.CreateNode<T>(_scenarioContext.StepContext.StepInfo.Text).Fail(_scenarioContext.TestError.Message + "\n" + _scenarioContext.TestError.StackTrace);
            }
            else
            {
                scenario?.CreateNode<T>(_scenarioContext.StepContext.StepInfo.Text);
            }
        }
    }
}