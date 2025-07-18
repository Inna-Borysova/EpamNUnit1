using OpenQA.Selenium;

namespace EpamNUnit1;

public class ArticlePage
{
    private readonly IWebDriver _driver;
    private readonly By titleArticle = By.XPath("//div[@class='header_and_download']");


    public ArticlePage(IWebDriver driver)
    {
        _driver = driver;
    }

    public string GetArticleTitle()
    {
        return _driver.FindElement(titleArticle).Text;
    }
}
