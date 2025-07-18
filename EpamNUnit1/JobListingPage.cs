using OpenQA.Selenium;

namespace EpamNUnit1;

public class JobListingPage
{
    private readonly IWebDriver _driver;
    private readonly By lastViewAndApplyButton = By.XPath("//ul[contains(@class, 'search-result__list')]//li[last()]//a[contains(text(), 'View and apply')]");
    private readonly By vacancyTitle = By.CssSelector($"header h1");

    public JobListingPage(IWebDriver driver)
    {
        _driver = driver;
    }

    public void ClickViewAndApplyButton()
    {
        _driver.FindElement(lastViewAndApplyButton).Click();
    }

    public bool IsVacancyTextContainsKeyword(string searchWord)
    {
        return GetVacancyText().Contains(searchWord, StringComparison.OrdinalIgnoreCase);
    }

    private string GetVacancyText()
    {
        return _driver.FindElement(vacancyTitle).Text;
    }
}
