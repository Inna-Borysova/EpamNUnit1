using EpamNUnit1.Helpers;
using OpenQA.Selenium;

namespace EpamNUnit1.Tests;

public abstract class BaseUITests : BaseTests
{
    protected IWebDriver _driver;

    [SetUp]
    public virtual void SetUp()
    {
        base.SetUp();

        ConfigManager configManager = ConfigManager.Instance;
        string browser = configManager.Browser;
        bool headless = configManager.Headless;
        string url = configManager.Url;

        _driver = DriverFactory.CreateConfigureDriver(browser, headless, null);

        _driver.Navigate().GoToUrl(url);
    }

    [TearDown]
    public virtual void TearDown()
    {
        if (TestContext.CurrentContext.Result.Outcome.Status == NUnit.Framework.Interfaces.TestStatus.Failed)
        {
            Logger.LogError<BaseUITests>("Test Failed: " + TestContext.CurrentContext.Test.Name);
            Logger.LogError<BaseUITests>("Error: " + TestContext.CurrentContext.Result.Message);

            string testName = TestContext.CurrentContext.Test.MethodName;
            Utility.TakeScreenshot(_driver, testName);
            Logger.LogInfo<BaseUITests>("Screenshot taken.");
        }
        else
        {
            Logger.LogInfo<BaseUITests>("Test Passed: " + TestContext.CurrentContext.Test.Name);
        }

        if (_driver != null)
        {
            _driver.Quit();
            _driver.Dispose();
        }
    }
}
