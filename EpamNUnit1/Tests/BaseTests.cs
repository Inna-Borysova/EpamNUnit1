using EpamNUnit1.Helpers;
using OpenQA.Selenium;

namespace EpamNUnit1.Tests;

public abstract class BaseTests
{
    protected IWebDriver _driver;
    protected string _downloadPath;

    public virtual void SetUp()
    {
        string browser = ConfigManager.Browser;
        bool headless = ConfigManager.Headless;
        string url = ConfigManager.Url;

        _downloadPath = Path.GetFullPath(Path.Combine(Path.GetTempPath(), "EpamDownloads"));

        if (Directory.Exists(_downloadPath))
        {
            Directory.Delete(_downloadPath, true);
        }

        _driver = DriverFactory.CreateConfigureDriver(browser, headless, _downloadPath);

        _driver.Navigate().GoToUrl(url);
    }

    public virtual void TearDown()
    {
        if (_driver != null)
        {
            _driver.Quit();
            _driver.Dispose();
        }
    }
}
