using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace EpamNUnit1;

[TestFixture("chrome")]
[TestFixture("firefox")]
public class EpamTests
{
    private readonly string _browser;
    private IWebDriver _driver;

    public EpamTests(string browser)
    {
        _browser = browser;
    }

    [SetUp]
    public void SetUp()
    {
        _driver = CreateConfigureDriver(_browser);
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
        _driver.Navigate().GoToUrl("https://www.epam.com/");

        By carries = By.LinkText("Careers");
        By keywordInput = By.Id("new_form_job_search-keyword");
        By location = By.CssSelector("div.recruiting-search__location");
        By body = By.TagName("body");
        By locationSelect = By.XPath("//li[@class='select2-results__option' and contains(text(), 'All Locations')]");
        By remoteCheckbox = By.XPath("//p[contains(@class,'job-search__filter-items--remote')]//label");
        By findButton = By.XPath("//form[@id='jobSearchFilterForm']//button[@type='submit']");
        By lastViewAndApplyButton = By.XPath("//ul[contains(@class, 'search-result__list')]//li[last()]//a[contains(text(), 'View and apply')]");
        By vacancyTitle = By.CssSelector($"header h1");

        _driver.FindElement(carries).Click();
        TryClickCookies(_driver);
        _driver.FindElement(keywordInput).SendKeys(searchWord);
        _driver.FindElement(location).Click();
        _driver.FindElement(locationSelect).Click();
        _driver.FindElement(keywordInput).Click();
        _driver.FindElement(body).Click();
        _driver.FindElement(remoteCheckbox).Click();
        _driver.FindElement(findButton).Click();
        _driver.FindElement(lastViewAndApplyButton).Click();
        string vacancyTitleText = _driver.FindElement(vacancyTitle).Text;

        bool res = vacancyTitleText.Contains(searchWord, StringComparison.OrdinalIgnoreCase);

        Assert.That(res, Is.True);
    }

    [Test]
    [TestCase("BLOCKCHAIN")]
    [TestCase("Cloud")]
    [TestCase("Automation")]
    public void Search_ByKeyword_LinksContainKeywordTest(string searchWord)
    {
        _driver.Navigate().GoToUrl("https://www.epam.com/");

        By searchIcon = By.ClassName("header__icon");
        By searchInput = By.TagName("input");
        By findButton = By.XPath("//div[contains(@class, 'search-results__action-section')]//button[contains(@class, 'custom-search-button')]");
        By searchOnPage = By.ClassName("search-results__title-link");

        _driver.FindElement(searchIcon).Click();
        _driver.FindElement(searchInput).SendKeys(searchWord);
        _driver.FindElement(findButton).Click();
        System.Collections.ObjectModel.ReadOnlyCollection<IWebElement> res = _driver.FindElements(searchOnPage);

        bool result =
            res
                .Where(x => !string.IsNullOrWhiteSpace(x.Text))
                .All(x => x.Text.Contains(searchWord, StringComparison.OrdinalIgnoreCase));

        Assert.That(result, Is.True);
    }

    private IWebDriver CreateDriver(string browser)
    {
        switch (browser)
        {
            case "chrome":
                {
                    return new ChromeDriver();

                }
            case "firefox":
                {
                    return new FirefoxDriver();
                }
            default:
                {
                    throw new ArgumentException();
                }
        }
    }

    private void MaximazeWindow(IWebDriver driver)
    {
        driver.Manage().Window.Maximize();
    }

    private void ImplicitWait(IWebDriver driver)
    {
        driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(15);
    }

    private void TryClickCookies(IWebDriver driver)
    {
        By cookiesBanner = By.Id("onetrust-banner-sdk");
        By cookiesButton = By.Id("onetrust-accept-btn-handler");

        WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));

        TryClick(driver, cookiesButton);

        wait.Until(x =>
        {
            var cookiesBannerElement = x.FindElement(cookiesBanner);
            return cookiesBannerElement == null || !cookiesBannerElement.Displayed;
        });
    }

    private void TryClick(IWebDriver driver, By locator)
    {
        for (int i = 0; i < 3; ++i)
        {
            try
            {
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
                wait.Until(ExpectedConditions.ElementToBeClickable(locator));
                driver.FindElement(locator).Click();
                break;
            }
            catch (ElementNotInteractableException)
            {
                continue;
            }
        }
    }

    private IWebDriver CreateConfigureDriver(string browser)
    {
        IWebDriver driver = CreateDriver(browser);
        MaximazeWindow(driver);
        ImplicitWait(driver);
        return driver;
    }
}