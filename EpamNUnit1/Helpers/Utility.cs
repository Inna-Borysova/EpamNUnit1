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

    public static void TakeScreenshot(IWebDriver driver, string testName)
    {
        string screenshotsDir = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Screenshots");
        Directory.CreateDirectory(screenshotsDir);

        string fileName = $"{testName}_{DateTime.Now:yyyy-MM-dd_HH-mm-ss}.png";
        string filePath = Path.Combine(screenshotsDir, fileName);

        Screenshot screenshot = ((ITakesScreenshot)driver).GetScreenshot();
        screenshot.SaveAsFile(filePath);
    }
}
