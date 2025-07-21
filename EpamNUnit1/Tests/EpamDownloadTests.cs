using EpamNUnit1.Helpers;
using EpamNUnit1.Pages;

namespace EpamNUnit1.Tests;

public class EpamDownloadTests : BaseTests
{
    protected string _downloadPath;

    [SetUp]
    public override void SetUp()
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

    [Test]
    public void DownloadFile_SuccessTest()
    {
        IndexPage indexPage = new IndexPage(_driver);
        indexPage.CheckCaptcha();
        indexPage.TryClickCookies();
        indexPage.ClickAboutButton();

        AboutPage aboutPage = new AboutPage(_driver);
        aboutPage.ScrollEpamAtGlanceSection();
        aboutPage.ClickDownloadButton();
        bool isDowloaded = aboutPage.WaitForCorporateOverviewDownload(_downloadPath);

        Assert.That(isDowloaded, Is.True);
    }
}
