using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;

namespace EpamNUnit1.Helpers;

public class DriverFactory
{
    public static IWebDriver CreateDriver(string browser, bool headless, string downloadPath)
    {
        switch (browser)
        {
            case "chrome":
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

            case "firefox":
                {
                    var profile = new FirefoxProfile();

                    profile.SetPreference("browser.download.folderList", 2);
                    profile.SetPreference("browser.download.dir", downloadPath);
                    profile.SetPreference("browser.helperApps.neverAsk.saveToDisk", "application/pdf,text/csv,application/octet-stream");
                    profile.SetPreference("pdfjs.disabled", true);
                    profile.SetPreference("browser.download.useDownloadDir", true);
                    profile.SetPreference("browser.helperApps.alwaysAsk.force", false);

                    var options = new FirefoxOptions
                    {
                        Profile = profile
                    };

                    if (headless)
                    {
                        options.AddArgument("--headless");
                        options.AddArgument("--disable-gpu");
                    }

                    return new FirefoxDriver(options);
                }

            default:
                {
                    throw new ArgumentException();
                }
        }

        
    }

    public static void MaximazeWindow(IWebDriver driver)
    {
        driver.Manage().Window.Maximize();
    }

    public static void ImplicitWait(IWebDriver driver)
    {
        driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
    }

    public static IWebDriver CreateConfigureDriver(string browser, bool headless, string downloadPath)
    {
        IWebDriver driver = CreateDriver(browser, headless, downloadPath);
        driver.Manage().Window.Maximize();
        ImplicitWait(driver);
        return driver;
    }
}
