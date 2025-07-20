using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

namespace EpamNUnit1.Helpers;

public class Utility
{
    public static bool WaitForFileDownload(IWebDriver driver, string downloadPath, string fileName)
    {
        new Actions(driver)
            .Pause(TimeSpan.FromSeconds(4))
            .Perform();

        string[] files = files = Directory.GetFiles(downloadPath);

        return files.Any(x => x.Contains(fileName));
    }

    public static void ScrollToElement(IWebDriver driver, IWebElement webElement)
    {
        new Actions(driver)
            .ScrollToElement(webElement)
            .Perform();
    }
}
