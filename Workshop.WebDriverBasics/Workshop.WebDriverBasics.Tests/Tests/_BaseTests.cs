using NUnit.Framework;
using OpenQA.Selenium;
using Workshop.WebDriverBasics.Tests.WebDriverCore;

namespace Workshop.WebDriverBasics.Tests.Tests
{
    public abstract class _BaseTests
    {
        private ThreadLocal<IWebDriver> _driver = new ThreadLocal<IWebDriver>();

        protected IWebDriver Driver => _driver.Value!;

        [SetUp]
        public void SetUp()
        {
            _driver.Value = new WebDriverFactory().CreateNewWebDriver(GlobalTestsSetup.BrowserOptions);
        }

        [TearDown]
        public void TearDown()
        {
            // Quit the WebDriver for the current thread
            if (_driver.Value != null)
            {
                _driver.Value?.Quit(); // Quit the WebDriver for the current thread
                _driver.Value = null!;  // Clear the reference
            }
        }
    }
}
