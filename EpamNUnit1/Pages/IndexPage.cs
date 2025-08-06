using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace EpamNUnit1.Pages;

public class IndexPage : BasePage
{
    private IWebElement Captcha => _driver.FindElement(By.XPath("//*[contains(text(), 'Verifying you are human')]"));
    private IWebElement CookiesBanner => _driver.FindElement(By.Id("onetrust-banner-sdk"));
    private IWebElement CookiesButton => _driver.FindElement(By.Id("onetrust-accept-btn-handler"));
    private IWebElement CarriesButton => _driver.FindElement(By.LinkText("Careers"));
    private IWebElement AboutButton => _driver.FindElement(By.LinkText("About"));
    private IWebElement InsightsButton => _driver.FindElement(By.LinkText("Insights"));
    private IWebElement SearchIcon => _driver.FindElement(By.ClassName("header__icon"));
    private IWebElement SearchInput => _driver.FindElement(By.TagName("input"));
    private IWebElement FindButton => _driver.FindElement(By.XPath("//div[contains(@class, 'search-results__action-section')]//button[contains(@class, 'custom-search-button')]"));
    private IWebElement ServicesLink => _driver.FindElement(By.LinkText("Services"));
    private System.Collections.ObjectModel.ReadOnlyCollection<IWebElement> TopNavigationLinks => _driver.FindElements(By.XPath("//a[@class='top-navigation__sub-link']"));

    public IndexPage(IWebDriver driver) : base(driver)
    {
    }

    public void ClickCarreesButton()
    {
        CarriesButton.Click();
    }
    public void ClickAboutButton()
    {
        AboutButton.Click();
    }

    public void ClickInsightsButton()
    {
        InsightsButton.Click();
    }

    public void ClickSearchIcon()
    {
        SearchIcon.Click();
    }

    public void TypeSearchInput(string searchWord)
    {
        SearchInput.SendKeys(searchWord);
    }

    public void ClickFindButton()
    {
        FindButton.Click();
    }

    public void HoverServisLink()
    {
        Actions actions = new Actions(_driver);
        actions.MoveToElement(ServicesLink).Perform();
    }

    public void ClickTopNavigationLink(string searchLink)
    {
        IWebElement generativeAiLink = TopNavigationLinks.First(x => string.Equals(x.Text, searchLink, StringComparison.OrdinalIgnoreCase));
        generativeAiLink.Click();
    }

    public void TryClickCookies()
    {
        for (int i = 0; i < 3; ++i)
        {
            try
            {
                var wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(5));
                wait.Until(ExpectedConditions.ElementToBeClickable(CookiesButton));
                CookiesButton.Click();
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

        WebDriverWait bannerDisappearWait = new WebDriverWait(_driver, TimeSpan.FromSeconds(5));

        bannerDisappearWait.Until(x => CookiesBanner == null || !CookiesBanner.Displayed);
    }

    public void CheckCaptcha()
    {
        try
        {
            if (Captcha != null && Captcha.Displayed)
            {
                throw new Exception("Captcha");
            }
        }
        catch (NoSuchElementException)
        {
            return;
        }
    }
}
