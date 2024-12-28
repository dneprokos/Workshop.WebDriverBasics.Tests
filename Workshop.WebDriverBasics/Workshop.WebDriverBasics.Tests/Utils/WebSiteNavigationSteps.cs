using FluentAssertions;
using OpenQA.Selenium;
using Workshop.WebDriverBasics.Tests.Pages;

namespace Workshop.WebDriverBasics.Tests.Utils
{
    public class WebSiteNavigationSteps
    {
        public void OpenAndLoginToWebSite(IWebDriver driver)
        {
            driver.Navigate().GoToUrl(GlobalTestsSetup.BaseUrl);
            new LoginPage(driver).SubmitLoginViaSessionStotage(
                GlobalTestsSetup.SessionStorageKey, GlobalTestsSetup.SessionStorageValue);
            new HomePage(driver).GetLogoText().Should().Be("QA Automation Web");
        }
    }
}
