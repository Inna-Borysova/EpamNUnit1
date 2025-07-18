using OpenQA.Selenium;

namespace EpamNUnit1;

public class CareersPage
{
    private readonly IWebDriver _driver;
    private readonly By keywordInput = By.Id("new_form_job_search-keyword");
    private readonly By location = By.CssSelector("div.recruiting-search__location");
    private readonly By body = By.TagName("body");
    private readonly By locationSelect = By.XPath("//li[@class='select2-results__option' and contains(text(), 'All Locations')]");
    private readonly By remoteCheckbox = By.XPath("//p[contains(@class,'job-search__filter-items--remote')]//label");
    private readonly By findButton = By.XPath("//form[@id='jobSearchFilterForm']//button[@type='submit']");

    public CareersPage(IWebDriver driver)
    {
        _driver = driver;
    }

    public void InputKeyword(string keyword)
    {
        _driver.FindElement(keywordInput).SendKeys(keyword);
        _driver.FindElement(keywordInput).Click();
        _driver.FindElement(body).Click();
    }

    public void SelectAllLocation()
    {
        _driver.FindElement(location).Click();
        _driver.FindElement(locationSelect).Click();
    }

    public void ClickRemoteCheckbox()
    {
        _driver.FindElement(remoteCheckbox).Click();
    }

    public void ClickFindButton()
    {
        _driver.FindElement(findButton).Click();
    }

}
