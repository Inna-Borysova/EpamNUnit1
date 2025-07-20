using EpamNUnit1.Pages;

namespace EpamNUnit1.Tests;

public class EpamTests : BaseTests
{
    [SetUp]
    public override void SetUp()
    {
        base.SetUp();
    }

    [TearDown]
    public override void TearDown()
    {
        base.TearDown();
    }

    [Test]
    [TestCase("java")]
    [TestCase(".net")]
    public void FindPosition_BySearchWord_PositionFoundTest(string searchWord)
    {
        IndexPage indexPage = new IndexPage(_driver);
        indexPage.CheckCaptcha();
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
        indexPage.CheckCaptcha();
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
        indexPage.CheckCaptcha();
        indexPage.TryClickCookies();
        indexPage.ClickAboutButton();

        AboutPage aboutPage = new AboutPage(_driver);
        aboutPage.ScrollEpamAtGlanceSection();
        aboutPage.ClickDownloadButton();
        bool isDowloaded = aboutPage.WaitForCorporateOverviewDownload(_downloadPath);

        Assert.That(isDowloaded, Is.True);
    }

    [Test]
    public void SelectArticleFromSlider_CorrectTitleTest()
    {
        const int countClick = 2;

        IndexPage indexPage = new IndexPage(_driver);
        indexPage.CheckCaptcha();
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
}