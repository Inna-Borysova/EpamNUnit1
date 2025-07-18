using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace EpamNUnit1;

public class IndexPage
{
    private readonly IWebDriver _driver;

    private readonly By cookiesBanner = By.Id("onetrust-banner-sdk");
    private readonly By cookiesButton = By.Id("onetrust-accept-btn-handler");
    private readonly By carriesButton = By.LinkText("Careers");
    private readonly By aboutButton = By.LinkText("About");
    private readonly By insightsButton = By.LinkText("Insights");
    private readonly By searchIcon = By.ClassName("header__icon");
    private readonly By searchInput = By.TagName("input");
    private readonly By findButton = By.XPath("//div[contains(@class, 'search-results__action-section')]//button[contains(@class, 'custom-search-button')]");

    public IndexPage(IWebDriver driver)
    {
        _driver = driver;
    }

    public void ClickCarriesButton()
    {
        _driver.FindElement(carriesButton).Click();
    }
    public void ClickAboutButton()
    {
        _driver.FindElement(aboutButton).Click();
    }

    public void ClickInsightsButton()
    {
        _driver.FindElement(insightsButton).Click();
    }

    public void ClickSearchIcon()
    {
        _driver.FindElement(searchIcon).Click();
    }

    public void TypeSearchInput(string searchWord)
    {
        _driver.FindElement(searchInput).SendKeys(searchWord);
    }

    public void ClickFindButton()
    {
        _driver.FindElement(findButton).Click();
    }

    public void TryClickCookies()
    {
        for (int i = 0; i < 3; ++i)
        {
            try
            {
                var wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(15));
                wait.Until(ExpectedConditions.ElementToBeClickable(cookiesButton));
                _driver.FindElement(cookiesButton).Click();
                break;
            }
            catch (ElementNotInteractableException)
            {
                continue;
            }
            catch (NoSuchElementException)
            {
                break;
            }
        }

        WebDriverWait bannerDisappearWait = new WebDriverWait(_driver, TimeSpan.FromSeconds(15));

        bannerDisappearWait.Until(x =>
        {
            var cookiesBannerElement = x.FindElement(cookiesBanner);
            return cookiesBannerElement == null || !cookiesBannerElement.Displayed;
        });
    }
}
