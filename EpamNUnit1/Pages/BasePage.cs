using OpenQA.Selenium;

namespace EpamNUnit1.Pages;

public abstract class BasePage
{
    protected IWebDriver _driver;

    public BasePage(IWebDriver driver)
    {
        _driver = driver;
    }

}
