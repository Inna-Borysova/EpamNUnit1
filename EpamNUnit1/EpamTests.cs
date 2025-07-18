using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace EpamNUnit1;

public class EpamTests
{
    private const string url = "https://www.epam.com/";
    private IWebDriver _driver;
    private string _downloadPath;

    [SetUp]
    public void SetUp()
    {
        _downloadPath = Path.GetFullPath(Path.Combine(Path.GetTempPath(), "EpamDownloads"));

        if (Directory.Exists(_downloadPath))
        {
            Directory.Delete(_downloadPath, true);
        }

        _driver = CreateConfigureDriver();

        _driver.Navigate().GoToUrl(url);
    }

    [TearDown]
    public void TearDown()
    {
        _driver.Quit();
        _driver.Dispose();
    }

    [Test]
    [TestCase("java")]
    [TestCase(".net")]
    public void FindPosition_BySearchWord_PositionFoundTest(string searchWord)
    {
        IndexPage indexPage = new IndexPage(_driver);
        indexPage.TryClickCookies();
        indexPage.ClickCarriesButton();

        CareersPage careersPage = new CareersPage(_driver);
        careersPage.ClickRemoteCheckbox();
        careersPage.InputKeyword(searchWord);
        careersPage.SelectAllLocation();
        careersPage.ClickFindButton();

        JobListingPage jobListingPage = new JobListingPage(_driver);
        jobListingPage.ClickViewAndApplyButton();
        bool result = jobListingPage.IsVacancyTextContainsKeyword(searchWord);

        Assert.That(result, Is.True);
    }

    [Test]
    [TestCase("BLOCKCHAIN")]
    [TestCase("Cloud")]
    [TestCase("Automation")]
    public void Search_ByKeyword_LinksContainKeywordTest(string searchWord)
    {
        IndexPage indexPage = new IndexPage(_driver);
        indexPage.ClickSearchIcon();
        indexPage.TypeSearchInput(searchWord);
        indexPage.ClickFindButton();

        SearchPage searchPage = new SearchPage(_driver);
        bool result = searchPage.IsGetSearchLinksContainsSearchword(searchWord);

        Assert.That(result, Is.True);
    }

    [Test]
    public void DownloadFile_SuccessTest()
    {
        IndexPage indexPage = new IndexPage(_driver);
        indexPage.TryClickCookies();
        indexPage.ClickAboutButton();

        AboutPage aboutPage = new AboutPage(_driver);
        aboutPage.ScrollEpamAtGlanceSection();
        aboutPage.ClickDownloadButton();
        bool isDowloaded = aboutPage.WaitForFileDownload(_driver, _downloadPath);

        Assert.That(isDowloaded, Is.True);
    }

    [Test]
    public void SelectArticleFromSlider_CorrectTitleTest()
    {
        const int countClick = 2;

        IndexPage indexPage = new IndexPage(_driver);
        indexPage.ClickInsightsButton();
        indexPage.TryClickCookies();

        InsightsPage insightsPage = new InsightsPage(_driver);
        insightsPage.SwipeCarousel(countClick);
        string slideText = insightsPage.GetSlideText();
        insightsPage.ClickReadMoreButton();

        ArticlePage articlePage = new ArticlePage(_driver);
        string articleTitle = articlePage.GetArticleTitle();

        bool result = articleTitle.Contains(slideText) || slideText.Contains(articleTitle);

        Assert.That(result, Is.True);
    }

    private IWebDriver CreateDriver()
    {
        var options = new ChromeOptions();
        options.AddUserProfilePreference("download.default_directory", _downloadPath);
        options.AddUserProfilePreference("download.prompt_for_download", false);
        options.AddUserProfilePreference("disable-popup-blocking", "true");
        return new ChromeDriver(options);
    }

    private void MaximazeWindow(IWebDriver driver)
    {
        driver.Manage().Window.Maximize();
    }

    private void ImplicitWait(IWebDriver driver)
    {
        driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(15);
    }

    private IWebDriver CreateConfigureDriver()
    {
        IWebDriver driver = CreateDriver();
        MaximazeWindow(driver);
        ImplicitWait(driver);
        return driver;
    }
}