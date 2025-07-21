using OpenQA.Selenium;

namespace EpamNUnit1.Pages;

public class JobListingPage : BasePage
{
    private IWebElement LastViewAndApplyButton => _driver.FindElement(By.XPath("//ul[contains(@class, 'search-result__list')]//li[last()]//a[contains(text(), 'View and apply')]"));
    private IWebElement VacancyTitle => _driver.FindElement(By.CssSelector($"header h1"));

    public JobListingPage(IWebDriver driver) : base(driver)
    {
    }

    public void ClickViewAndApplyButton()
    {
        LastViewAndApplyButton.Click();
    }

    public bool IsVacancyTextContainsKeyword(string searchWord)
    {
        return GetVacancyText().Contains(searchWord, StringComparison.OrdinalIgnoreCase);
    }

    private string GetVacancyText()
    {
        return VacancyTitle.Text;
    }
}
