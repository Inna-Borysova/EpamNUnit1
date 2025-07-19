using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace EpamNUnit1;

public class DriverFactory
{
    public static IWebDriver CreateDriver(string downloadPath, bool headless)
    {
        var options = new ChromeOptions();
        options.AddUserProfilePreference("download.default_directory", downloadPath);
        options.AddUserProfilePreference("download.prompt_for_download", false);
        options.AddUserProfilePreference("disable-popup-blocking", "true");

        if (headless)
        {
            options.AddArgument("--headless=new");
            options.AddArgument("--window-size=1920,1080");
            options.AddArgument("--disable-gpu");
            options.AddArgument("--no-sandbox");
        }

        return new ChromeDriver(options);
    }

    public static void MaximazeWindow(IWebDriver driver)
    {
        driver.Manage().Window.Maximize();
    }

    public static void ImplicitWait(IWebDriver driver)
    {
        driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
    }

    public static IWebDriver CreateConfigureDriver(string downloadPath, bool headless)
    {
        IWebDriver driver = CreateDriver(downloadPath, headless);
        driver.Manage().Window.Maximize();
        ImplicitWait(driver);
        return driver;
    }
}
