using FluentAssertions;
using NUnit.Framework;
using OpenQA.Selenium;
using Workshop.WebDriverBasics.Tests.Pages;

namespace Workshop.WebDriverBasics.Tests.Tests
{
    [Parallelizable(ParallelScope.All)]
    public class LoginFeatureTests : _BaseTests
    {
        [Test]
        public void Login_ValidCredentials_ShouldBeLoggedIn()
        {
            // Arrange
            Driver.Navigate().GoToUrl(GlobalTestsSetup.BaseUrl);

            // Act
            new LoginPage(Driver).SubmitLogin(GlobalTestsSetup.CredLogin, GlobalTestsSetup.CredPassword);

            // Assert
            Driver.Url.Should().Be($"{GlobalTestsSetup.BaseUrl}/home", 
                "The actual URL does not match the expected URL.");

            // Verify the text content
            new HomePage(Driver).GetLogoText().Should().Be("QA Automation Web");
        }

        [Test]
        public void Login_ValidInvalidPassword_ShouldNotBeLoggedIn()
        {
            // Arrange
            Driver.Navigate().GoToUrl(GlobalTestsSetup.BaseUrl);

            // Act
            new LoginPage(Driver).SubmitLogin("test@test.com", "wrong");

            // Assert
            IAlert alert = Driver.SwitchTo().Alert();
            alert.Text.Should().Be("Invalid credentials");
            alert.Accept();
        }
    }
}
