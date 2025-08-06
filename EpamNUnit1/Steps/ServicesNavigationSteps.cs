using EpamNUnit1.Helpers;
using EpamNUnit1.Pages;
using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace BddFrameworks.Steps;

[Binding]
[Scope(Tag = "UI")]
public class ServicesNavigationSteps
{
    private IWebDriver _driver;
    private IndexPage _indexPage;
    private ServicesArtificialIntelligencePage _servicesArtificialIntelligencePage;

    public ServicesNavigationSteps(ScenarioContext context)
    {
        _driver = context.Get<IWebDriver>("WebDriver");
        _indexPage = new IndexPage(_driver);
        _servicesArtificialIntelligencePage = new ServicesArtificialIntelligencePage(_driver);
    }

    [When(@"I navigate to the Services section and select ""(.*)""")]
    public void WhenINavigateToTheServicesSectionAndSelect(string searchWord)
    {
        _indexPage.HoverServisLink();
        _indexPage.ClickTopNavigationLink(searchWord);
    }

    [Then(@"I should see the page title containing ""(.*)""")]
    public void ThenIShouldSeeThePageTitleContaining(string category)
    {
        bool titleTextContainsSearchWord = _servicesArtificialIntelligencePage.IsTitleTextContainsSearchWord(category);
        Assert.That(titleTextContainsSearchWord, Is.True);

    }

    [Then(@"the section ""(.*)"" should be visible")]
    public void ThenTheSectionShouldBeVisible(string sectionTitle)
    {
        _servicesArtificialIntelligencePage.ScrollOurRelatedExpertiseSection();
        bool ourRelatedExpertiseSectionDisplayed = _servicesArtificialIntelligencePage.IsOurRelatedExpertiseSectionDisplayed();
        Assert.That(ourRelatedExpertiseSectionDisplayed, Is.True);
    }
}
