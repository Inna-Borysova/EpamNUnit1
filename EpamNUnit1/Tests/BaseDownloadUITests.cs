using EpamNUnit1.Helpers;

namespace EpamNUnit1.Tests;

public class BaseDownloadUITests : BaseUITests
{
    protected string _downloadPath;

    [SetUp]
    public override void SetUp()
    {
        ConfigManager configManager = ConfigManager.Instance;
        string browser = configManager.Browser;
        bool headless = configManager.Headless;
        string url = configManager.Url;

        _downloadPath = Path.GetFullPath(Path.Combine(Path.GetTempPath(), "EpamDownloads"));

        if (Directory.Exists(_downloadPath))
        {
            Directory.Delete(_downloadPath, true);
        }

        _driver = DriverFactory.CreateConfigureDriver(browser, headless, _downloadPath);

        _driver.Navigate().GoToUrl(url);
    }

    [TearDown]
    public override void TearDown()
    {
        base.TearDown();

        if (Directory.Exists(_downloadPath))
        {
            Directory.Delete(_downloadPath, true);
        }
    }
}
