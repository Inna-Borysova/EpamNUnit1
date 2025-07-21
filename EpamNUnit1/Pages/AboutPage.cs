using EpamNUnit1.Helpers;
using OpenQA.Selenium;

namespace EpamNUnit1.Pages;

public class AboutPage : BasePage
{
    private const string fileName = "EPAM_Corporate_Overview";
    private IWebElement EpamAtGlanceSection => _driver.FindElement(By.XPath("//span[contains(text(),'EPAM at')]"));
    private IWebElement DownloadButton => _driver.FindElement(By.XPath("//a[@download]"));

    public AboutPage(IWebDriver driver) : base(driver)
    {
    }

    public void ScrollEpamAtGlanceSection()
    {
        Utility.ScrollToElement(_driver, EpamAtGlanceSection);
    }

    public void ClickDownloadButton()
    {
        DownloadButton.Click();
    }

    public bool WaitForCorporateOverviewDownload(string downloadPath)
    {
        return Utility.WaitForFileDownload(_driver, downloadPath, fileName);
    }
}
