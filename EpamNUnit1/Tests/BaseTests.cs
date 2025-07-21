using EpamNUnit1.Helpers;
using OpenQA.Selenium;

namespace EpamNUnit1.Tests;

public abstract class BaseTests
{
    protected IWebDriver _driver;

    [SetUp]
    public virtual void SetUp()
    {
        string browser = ConfigManager.Browser;
        bool headless = ConfigManager.Headless;
        string url = ConfigManager.Url;

        _driver = DriverFactory.CreateConfigureDriver(browser, headless, null);

        _driver.Navigate().GoToUrl(url);
    }

    [TearDown]
    public virtual void TearDown()
    {
        if (_driver != null)
        {
            _driver.Quit();
            _driver.Dispose();
        }
    }
}
