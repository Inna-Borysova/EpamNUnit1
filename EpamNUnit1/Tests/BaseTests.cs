using EpamNUnit1.Helpers;
using log4net;
using log4net.Config;
using Microsoft.VisualStudio.TestPlatform.ObjectModel;
using OpenQA.Selenium;
using System.Reflection;

namespace EpamNUnit1.Tests;

public abstract class BaseTests
{
    protected IWebDriver _driver;
    protected static readonly ILog Log = LogManager.GetLogger(MethodBase.GetCurrentMethod()?.DeclaringType);

    [OneTimeSetUp]
    public void GlobalSetUp()
    {
        var logRepository = LogManager.GetRepository(Assembly.GetEntryAssembly() ?? Assembly.GetExecutingAssembly());
        XmlConfigurator.Configure(logRepository, new FileInfo("log4net.config"));

        Log.Info("=== TEST RUN STARTED ===");
    }

    [SetUp]
    public virtual void SetUp()
    {
        Log.Info("Test Started: " + TestContext.CurrentContext.Test.Name);

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
            Log.Error("Test Failed: " + TestContext.CurrentContext.Test.Name);
            Log.Error("Error: " + TestContext.CurrentContext.Result.Message);

            string testName = TestContext.CurrentContext.Test.MethodName;
            Utility.TakeScreenshot(_driver, testName);
            Log.Info("Screenshot taken.");
        }
        else
        {
            Log.Info("Test Passed: " + TestContext.CurrentContext.Test.Name);
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
        Log.Info("=== TEST RUN FINISHED ===");
    }
}
