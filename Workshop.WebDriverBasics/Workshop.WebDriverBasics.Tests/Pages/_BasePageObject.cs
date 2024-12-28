using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;

namespace Workshop.WebDriverBasics.Tests.Pages
{
    public abstract class _BasePageObject
    {
        protected IWebDriver _driver;
        protected WebDriverWait _wait;

        protected _BasePageObject(IWebDriver webDriver)
        {
            _driver = webDriver;
            _wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
        }
    }
}
