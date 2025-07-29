using EpamNUnit1.Helpers;
using OpenQA.Selenium;

namespace EpamNUnit1.Tests;

public abstract class BaseTests
{
    protected IWebDriver _driver;

    [OneTimeSetUp]
    public void GlobalSetUp()
    {
        Logger.LogInfo<BaseTests>("=== TEST RUN STARTED ===");
    }

    [SetUp]
    public virtual void SetUp()
    {
        Logger.LogInfo<BaseTests>("Test Started: " + TestContext.CurrentContext.Test.Name);

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
            Logger.LogError<BaseTests>("Test Failed: " + TestContext.CurrentContext.Test.Name);
            Logger.LogError<BaseTests>("Error: " + TestContext.CurrentContext.Result.Message);

            string testName = TestContext.CurrentContext.Test.MethodName;
            Utility.TakeScreenshot(_driver, testName);
            Logger.LogInfo<BaseTests>("Screenshot taken.");
        }
        else
        {
            Logger.LogInfo<BaseTests>("Test Passed: " + TestContext.CurrentContext.Test.Name);
        }

        if (_driver != null)
        {
            _driver.Quit();
            _driver.Dispose();
        }
    }

    [OneTimeTearDown]
    public void GlobalTearDown()
    {
        Logger.LogInfo<BaseTests>("=== TEST RUN FINISHED ===");
    }
}
