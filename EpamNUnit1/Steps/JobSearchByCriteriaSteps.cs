using EpamNUnit1.Pages;
using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace EpamNUnit1.Steps;

[Binding]
[Scope(Tag = "UI")]
public class JobSearchByCriteriaSteps
{
    private IWebDriver _driver;
    private IndexPage _indexPage;
    private CareersPage _careersPage;
    private JobListingPage _jobListingPage;

    public JobSearchByCriteriaSteps(ScenarioContext context)
    {
        _driver = context.Get<IWebDriver>("WebDriver");
        _indexPage = new IndexPage(_driver);
        _careersPage = new CareersPage(_driver);
        _jobListingPage = new JobListingPage(_driver);
    }

    [When(@"I navigate to the ""Careers"" page")]
    public void WhenINavigateToThePage()
    {
        _indexPage.ClickCarreesButton();
    }

    [When(@"I enter ""(.*)"" into the ""Keywords"" field")]
    public void WhenIEnterIntoTheKeywordsField(string programmingLanguage)
    {
        _careersPage.InputKeyword(programmingLanguage);
    }

    [When(@"I select ""All Location"" from the ""Location"" dropdown")]
    public void WhenISelectFromTheLocationDropdown()
    {
        _careersPage.SelectAllLocation();
    }

    [When(@"I select the ""Remote"" option")]
    public void WhenISelectTheRemoteOption()
    {
        _careersPage.ClickRemoteCheckbox();
    }

    [When(@"I click the ""Find"" button")]
    public void WhenIClickTheFindButton()
    {
        _careersPage.ClickFindButton();
    }

    [When(@"I click the “View and apply” button in the latest job post from the search results")]
    public void WhenTheUserOpensTheLatestJobPostFromTheSearchResults()
    {
        _jobListingPage.ClickViewAndApplyButton();
    }

    [Then(@"the job description page should contain the word ""(.*)""")]
    public void ThenTheJobDescriptionPageShouldContainTheWord(string programmingLanguage)
    {
        bool result = _jobListingPage.IsVacancyTextContainsKeyword(programmingLanguage);

        Assert.That(result, Is.True);
    }

}
