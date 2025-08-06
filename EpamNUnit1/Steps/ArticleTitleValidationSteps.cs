using EpamNUnit1.Pages;
using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace EpamNUnit1.Steps;

[Binding]
[Scope(Tag = "UI")]
public class ArticleTitleValidationSteps
{
    private IWebDriver _driver;
    private IndexPage _indexPage;
    private InsightsPage _insightsPage;
    private ArticlePage _articlePage;
    private const int countClick = 2;
    private string _articleTitle;
    private string _slideText;

    public ArticleTitleValidationSteps(ScenarioContext context)
    {
        _driver = context.Get<IWebDriver>("WebDriver");
        _indexPage = new IndexPage(_driver);
        _insightsPage = new InsightsPage(_driver);
        _articlePage = new ArticlePage(_driver);
    }

    [When(@"I select ""Insights"" from the top menu")]
    public void WhenISelectFromTheTopMenu()
    {
        _indexPage.ClickInsightsButton();
    }

    [When(@"I swipe the carousel two times")]
    public void WhenISwipeTheCarouselTwoTimes()
    {
        _insightsPage.SwipeCarousel(countClick);
    }

    [When(@"I note the title of the current article in the carousel")]
    public void WhenINoteTheTitleOfTheCurrentArticleInTheCarousel()
    {
        _slideText = _insightsPage.GetSlideText();
    }

    [When(@"I click the ""Read More"" button of the current article")]
    public void WhenIClickTheReadMoreButtonOfTheCurrentArticle()
    {
        _insightsPage.ClickReadMoreButton();
    }

    [Then(@"the article title on the article page should match the noted title")]
    public void ThenTheArticleTitleShouldMatchTheNotedTitle()
    {
        _articleTitle = _articlePage.GetArticleTitle();
        bool result = _articleTitle.Contains(_slideText) || _slideText.Contains(_articleTitle);

        Assert.That(result, Is.True);
    }
}
