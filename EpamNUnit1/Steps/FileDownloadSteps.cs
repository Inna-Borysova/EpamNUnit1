using EpamNUnit1.Helpers;
using EpamNUnit1.Pages;
using OpenQA.Selenium;
using OpenQA.Selenium.BiDi.Communication;
using TechTalk.SpecFlow;

namespace EpamNUnit1.Steps;

[Binding]
[Scope(Tag = "DownloadUI")]
public class FileDownloadSteps
{
    private IWebDriver _driver;
    private IndexPage _indexPage;
    private AboutPage _aboutPage;
    protected string _downloadPath;
    private bool _isDowloaded;

    public FileDownloadSteps(ScenarioContext context)
    {
        _driver = context.Get<IWebDriver>("WebDriver");
        _downloadPath = context.Get<string>("DownloadPath");
        _aboutPage = new AboutPage(_driver);
        _indexPage = new IndexPage(_driver);
        _aboutPage = new AboutPage(_driver);
    }

    [When(@"I select ""About"" from the top menu")]
    public void WhenISelectFromTheTopMenu()
    {
        _indexPage.ClickAboutButton();
    }

    [When(@"I scroll to the ""EPAM at a Glance"" section")]
    public void WhenIScrollToTheSection()
    {
        _aboutPage.ScrollEpamAtGlanceSection();
    }

    [When(@"I click the ""Download"" button")]
    public void WhenIClickTheDownloadButton()
    {
        _aboutPage.ClickDownloadButton();
    }

    [When(@"I wait for the file ""EPAM_Systems_Company_Overview.pdf"" to download")]
    public void WhenIWaitForTheFileToDownload()
    {
        _isDowloaded = _aboutPage.WaitForCorporateOverviewDownload(_downloadPath);
    }

    [Then(@"the file ""EPAM_Systems_Company_Overview.pdf"" should exist in the download folder")]
    public void ThenTheFileShouldExistInTheDownloadFolder()
    {
        Assert.That(_isDowloaded, Is.True);
    }
}
