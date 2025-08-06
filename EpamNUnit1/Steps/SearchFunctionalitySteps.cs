using EpamNUnit1.Pages;
using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace EpamNUnit1.Steps;

[Binding]
[Scope(Tag = "UI")]
public class SearchFunctionalitySteps
{
    private IWebDriver _driver;
    private IndexPage _indexPage;
    private SearchPage _searchPage;

    public SearchFunctionalitySteps(ScenarioContext context)
    {
        _driver = context.Get<IWebDriver>("WebDriver");
        _indexPage = new IndexPage(_driver);
        _searchPage = new SearchPage(_driver);
    }

    [When(@"I click on the Search icon element")]
    public void WhenIClickOnTheSearchIconElement()
    {
        _indexPage.ClickSearchIcon();
    }

    [When(@"I enter the text ""(.*)"" into the search input")]
    public void WhenIEnterTheTextIntoTheSearchInput(string text)
    {
        _indexPage.TypeSearchInput(text);
    }

    [When(@"I click on the Find button")]
    public void WhenIClickOnTheFindButton()
    {
        _indexPage.ClickFindButton();
    }

    [When(@"the user acceptes cookies")]
    public void WhenTheUserAcceptsCookies()
    {
        _indexPage.TryClickCookies();
    }

    [Then(@"all links in the list contain the text ""(.*)""")]
    public void ThenAllLinksInTheListContainText(string text)
    {
        bool result = _searchPage.IsGetSearchLinksContainsSearchword(text);

        Assert.That(result, Is.True);
    }
}
