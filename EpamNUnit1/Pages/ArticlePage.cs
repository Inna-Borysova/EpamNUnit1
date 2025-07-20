using OpenQA.Selenium;

namespace EpamNUnit1.Pages;

public class ArticlePage : BasePage
{
    private IWebElement TitleArticle => _driver.FindElement(By.XPath("//div[@class='header_and_download']"));

    public ArticlePage(IWebDriver driver) : base(driver)
    {
    }

    public string GetArticleTitle()
    {
        return TitleArticle.Text;
    }
}
