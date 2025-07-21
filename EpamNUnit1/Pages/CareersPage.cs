using OpenQA.Selenium;

namespace EpamNUnit1.Pages;

public class CareersPage : BasePage
{
    private IWebElement KeywordInput => _driver.FindElement(By.Id("new_form_job_search-keyword"));
    private IWebElement Location => _driver.FindElement(By.CssSelector("div.recruiting-search__location"));
    private IWebElement Body => _driver.FindElement(By.TagName("body"));
    private IWebElement LocationSelect => _driver.FindElement(By.XPath("//li[@class='select2-results__option' and contains(text(), 'All Locations')]"));
    private IWebElement RemoteCheckbox => _driver.FindElement(By.XPath("//p[contains(@class,'job-search__filter-items--remote')]//label"));
    private IWebElement FindButton => _driver.FindElement(By.XPath("//form[@id='jobSearchFilterForm']//button[@type='submit']"));

    public CareersPage(IWebDriver driver) : base(driver)
    {
    }

    public void InputKeyword(string keyword)
    {
        KeywordInput.SendKeys(keyword);
        KeywordInput.Click();
        Body.Click();
    }

    public void SelectAllLocation()
    {
        Location.Click();
        LocationSelect.Click();
    }

    public void ClickRemoteCheckbox()
    {
        RemoteCheckbox.Click();
    }

    public void ClickFindButton()
    {
        FindButton.Click();
    }

}
