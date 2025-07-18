using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

namespace EpamNUnit1;

public class AboutPage
{
    private IWebDriver _driver;
    private readonly By epamAtGlanceSection = By.XPath("//span[contains(text(),'EPAM at')]");
    private readonly By downloadButton = By.XPath("//a[@download]");

    public AboutPage(IWebDriver driver)
    {
        _driver = driver;
    }

    public void ScrollEpamAtGlanceSection()
    {
        _driver.FindElement(epamAtGlanceSection);

        new Actions(_driver)
            .ScrollToElement(_driver.FindElement(epamAtGlanceSection))
            .Perform();
    }

    public void ClickDownloadButton()
    {
        _driver.FindElement(downloadButton).Click();
    }

    public bool WaitForFileDownload(IWebDriver driver, string downloadPath)
    {
        new Actions(driver)
            .Pause(TimeSpan.FromSeconds(4))
            .Perform();

        string[] files = files = Directory.GetFiles(downloadPath);

        return files.Any(x => x.Contains("EPAM_Corporate_Overview"));
    }
}
