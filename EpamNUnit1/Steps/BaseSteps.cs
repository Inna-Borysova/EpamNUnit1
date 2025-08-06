using EpamNUnit1.Pages;
using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace EpamNUnit1.Steps;

[Binding]
public class BaseSteps
{
    private const string url = "https://www.epam.com/";
    private IWebDriver _driver;
    protected IndexPage _indexPage;

    public BaseSteps(ScenarioContext context)
    {
        _driver = context.Get<IWebDriver>("WebDriver");
        _indexPage = new IndexPage(_driver);
    }

    [Given(@"I am on the EPAM homepage")]
    public void GivenIAmOnTheEpamHomepage()
    {
        _driver.Navigate().GoToUrl(url);
    }

    [When(@"I accept cookies")]
    public void WhenIAcceptCookies()
    {
        _indexPage.TryClickCookies();

    }
}
