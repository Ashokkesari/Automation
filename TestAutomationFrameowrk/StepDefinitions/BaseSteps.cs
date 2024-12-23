using NUnit.Framework;
using OpenQA.Selenium;

namespace UITestLayer.StepDefinitions
{
    public class BaseSteps:Steps
    {
        ScenarioContext ScenarioContext;
        protected IWebDriver Driver;
        public BaseSteps(ScenarioContext context) 
        {
            ScenarioContext = context;
            Driver= ScenarioContext.Get<IWebDriver>("Driver");
        }
    }
}
