using OpenQA.Selenium;

namespace EpamNUnit1;

public class SearchPage
{
    private readonly IWebDriver _driver;
    private readonly By searchOnPage = By.ClassName("search-results__title-link");

    public SearchPage(IWebDriver driver)
    {
        _driver = driver;
    }

    public bool IsGetSearchLinksContainsSearchword(string searchWord)
    {
        return GetSearchLinks()
                .Where(x => !string.IsNullOrWhiteSpace(x.Text))
                .All(x => x.Text.Contains(searchWord, StringComparison.OrdinalIgnoreCase));
    }
    private System.Collections.ObjectModel.ReadOnlyCollection<IWebElement> GetSearchLinks()
    {
        return _driver.FindElements(searchOnPage);
    }
}
