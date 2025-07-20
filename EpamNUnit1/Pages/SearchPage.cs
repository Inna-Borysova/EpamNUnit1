using OpenQA.Selenium;

namespace EpamNUnit1.Pages;

public class SearchPage : BasePage
{
    private System.Collections.ObjectModel.ReadOnlyCollection<IWebElement> SearchLinks => _driver.FindElements(By.ClassName("search-results__title-link"));

    public SearchPage(IWebDriver driver) : base(driver)
    {
    }

    public bool IsGetSearchLinksContainsSearchword(string searchWord)
    {
        return SearchLinks
                .Where(x => !string.IsNullOrWhiteSpace(x.Text))
                .All(x => x.Text.Contains(searchWord, StringComparison.OrdinalIgnoreCase));
    }
}
