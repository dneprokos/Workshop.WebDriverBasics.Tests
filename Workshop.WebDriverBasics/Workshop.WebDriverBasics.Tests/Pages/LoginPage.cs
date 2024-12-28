using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;

namespace Workshop.WebDriverBasics.Tests.Pages
{
    public class LoginPage : _BasePageObject
    {
        public LoginPage(IWebDriver webDriver) : base(webDriver)
        {
        }

        private IWebElement _loginInputLocator => _wait
            .Until(ExpectedConditions.ElementIsVisible(By.Id("login")));
        private IWebElement _passwordInputLocator => _wait
            .Until(ExpectedConditions.ElementIsVisible(By.Id("password")));
        private IWebElement _loginBtnLocator => _wait
            .Until(ExpectedConditions.ElementToBeClickable(By.ClassName("mat-button-base")));

        public void SubmitLogin(string login, string password)
        {
            _loginInputLocator.SendKeys(login);
            _passwordInputLocator.SendKeys(password);
            _loginBtnLocator.Click();
        }

        public void SubmitLoginViaSessionStotage(string key, string value)
        {
            IJavaScriptExecutor jsExecutor = (IJavaScriptExecutor)_driver;
            jsExecutor.ExecuteScript($"sessionStorage.setItem('{key}', '{value}');");
            _driver.Navigate().Refresh();
        }
    }
}
