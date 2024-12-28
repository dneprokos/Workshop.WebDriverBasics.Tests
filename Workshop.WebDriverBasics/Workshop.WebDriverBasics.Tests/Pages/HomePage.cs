using FluentAssertions;
using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;

namespace Workshop.WebDriverBasics.Tests.Pages
{
    public class HomePage : _BasePageObject
    {
        public HomePage(IWebDriver webDriver) : base(webDriver)
        {
        }

        private IWebElement _siteLogoLocator => _wait
            .Until(ExpectedConditions.ElementIsVisible(By.XPath("//span[text()='QA Automation Web']")));

        private IWebElement _homePageHeaderLocator => _wait
            .Until(ExpectedConditions.ElementIsVisible(By.XPath("//h1")));

        public void Navigate(string baseUrl)
        {
            _driver.Navigate().GoToUrl($"{baseUrl}/home");
            _homePageHeaderLocator.Text
                .Should()
                .Contain("Test website designed for the automation practice. I know, site design is painful.");
        }

        public string GetLogoText() => _siteLogoLocator.Text;
    }
}
