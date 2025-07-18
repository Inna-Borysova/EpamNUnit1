using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

namespace EpamNUnit1;

public class InsightsPage
{
    private readonly IWebDriver _driver;
    private readonly By sliderRightArrow = By.XPath("//button[@class='slider__right-arrow slider-navigation-arrow']");
    private readonly By slideContent = By.XPath("//div[contains(@class, 'slider section')]//div[contains(@class, 'owl-item') and contains(@class, 'active')]//div[contains(@class, 'single-slide__content-container')]");
    private readonly By readMoreButton = By.CssSelector("div.owl-item.active div.single-slide__cta-container a");

    public InsightsPage(IWebDriver driver)
    {
        _driver = driver;
    }

    public void SwipeCarousel(int countClick)
    {
        Actions actions = new Actions(_driver).Pause(TimeSpan.FromSeconds(1));

        for (int i = 0; i < countClick; i++)
        {
            _driver.FindElement(sliderRightArrow).Click();
            actions.Perform();
        }
    }

    public string GetSlideText()
    {
        return _driver.FindElement(slideContent).Text;
    }

    public void ClickReadMoreButton()
    {
        _driver.FindElement(readMoreButton).Click();
    }
}