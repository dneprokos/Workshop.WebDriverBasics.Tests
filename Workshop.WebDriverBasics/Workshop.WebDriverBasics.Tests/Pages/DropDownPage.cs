using FluentAssertions;
using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;

namespace Workshop.WebDriverBasics.Tests.Pages
{
    public class DropDownPage : _BasePageObject
    {
        public DropDownPage(IWebDriver webDriver) : base(webDriver)
        {
        }

        private IWebElement _firstDropDownHeaderLocator => _wait
            .Until(ExpectedConditions.ElementIsVisible(By.XPath("//h4")));

        public void Navigate(string baseUrl)
        {
            //--- URL navigation does not work in my application. That's a bug. ---
            //_driver.Navigate().GoToUrl($"{baseUrl}/drop-down");

            //Workaround
            IWebElement dropdownButton = _wait.Until(ExpectedConditions
                .ElementToBeClickable(By.XPath("//a[@href='/drop-down']")));
            dropdownButton.Click();

            _firstDropDownHeaderLocator.Text
                .Should()
            .Be("mat-select");
        }

        public void SelectFavoriteFoodOption(string favoriteFood)
        {
            IWebElement dropdown = _wait.Until(ExpectedConditions.ElementToBeClickable(By.Id("mat-select-0")));
            dropdown.Click();

            IWebElement option = _wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath($"//mat-option//span[normalize-space(text())='{favoriteFood}']")));
            option.Click();
        }

        public string GetFavoriteFoodSelectedOption()
        {
            IWebElement selectedValue = _wait.Until(ExpectedConditions
                .ElementIsVisible(By.CssSelector("#mat-select-value-1")));
            return selectedValue.Text;
        }
    }
}
