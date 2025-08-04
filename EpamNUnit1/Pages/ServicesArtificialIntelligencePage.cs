using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

namespace EpamNUnit1.Pages;

public class ServicesArtificialIntelligencePage : BasePage
{
    private IWebElement TitleText => _driver.FindElement(By.XPath("//div[@class='colctrl__holder']"));
    private IWebElement OurRelatedExpertiseSection => _driver.FindElement(By.XPath("//span[@class='museo-sans-light' and contains(text(), 'Our Related Expertise')]"));

    public ServicesArtificialIntelligencePage(IWebDriver driver) : base(driver)
    {
    }

    public bool IsTitleTextContainsSearchWord(string searchWord)
    {
        return GetTitleText().Contains(searchWord, StringComparison.OrdinalIgnoreCase);
    }

    public void ScrollOurRelatedExpertiseSection()
    {
        ScrollToElement(_driver, OurRelatedExpertiseSection);
    }

    public bool IsOurRelatedExpertiseSectionDisplayed()
    {
        if (OurRelatedExpertiseSection.Displayed)
        {
            return true;
        }

        return false;
    }

    private string GetTitleText()
    {
        return TitleText.Text;
    }
    private void ScrollToElement(IWebDriver driver, IWebElement webElement)
    {
        new Actions(driver)
            .ScrollToElement(webElement)
            .Perform();
    }
}
