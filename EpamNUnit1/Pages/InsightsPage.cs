using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

namespace EpamNUnit1.Pages;

public class InsightsPage : BasePage
{
    private IWebElement SliderRightArrow => _driver.FindElement(By.XPath("//button[@class='slider__right-arrow slider-navigation-arrow']"));
    private IWebElement SlideContent => _driver.FindElement(By.XPath("//div[contains(@class, 'slider section')]//div[contains(@class, 'owl-item') and contains(@class, 'active')]//div[contains(@class, 'single-slide__content-container')]"));
    private IWebElement ReadMoreButton => _driver.FindElement(By.CssSelector("div.owl-item.active div.single-slide__cta-container a"));

    public InsightsPage(IWebDriver driver) : base(driver)
    {
    }

    public void SwipeCarousel(int countClick)
    {
        Actions actions = new Actions(_driver).Pause(TimeSpan.FromSeconds(1));

        for (int i = 0; i < countClick; i++)
        {
            SliderRightArrow.Click();
            actions.Perform();
        }
    }

    public string GetSlideText()
    {
        return SlideContent.Text;
    }

    public void ClickReadMoreButton()
    {
        ReadMoreButton.Click();
    }
}