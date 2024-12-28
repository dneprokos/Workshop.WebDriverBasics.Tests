using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;

namespace Workshop.WebDriverBasics.Tests.WebDriverCore
{
    public class WebDriverFactory
    {
        public IWebDriver CreateNewWebDriver(WebDriverOptions driverOptions)
        {
            IWebDriver? driver;
            string browser = driverOptions.Browser!;

            switch (browser.ToLowerInvariant())
            {
                case "chrome":
                    var chromeOptions = new ChromeOptions();
                    if (driverOptions.IsHeadless)
                        chromeOptions.AddArgument("--headless");

                    driver = new ChromeDriver(chromeOptions);
                    break;
                case "firefox":
                    var firefoxOptions = new FirefoxOptions();
                    if (driverOptions.IsHeadless)
                        firefoxOptions.AddArgument("--headless");
                    driver = new FirefoxDriver(firefoxOptions);
                    break;
                default:
                    throw new NotImplementedException($"Browser '{browser}' implementation is not available");
            }

            driver.Manage().Window.Maximize();

            return driver!;
        }
    }
}
