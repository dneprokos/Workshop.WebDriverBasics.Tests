using FluentAssertions;
using NUnit.Framework;
using Workshop.WebDriverBasics.Tests.Pages;
using Workshop.WebDriverBasics.Tests.Utils;

namespace Workshop.WebDriverBasics.Tests.Tests
{
    [Parallelizable(ParallelScope.All)]
    public class DropDownFeatureTests : _BaseTests
    {
        [Test]
        public void DropDown_SelectValue_ShouldBeSelected()
        {
            // Arrange
            new WebSiteNavigationSteps().OpenAndLoginToWebSite(Driver);
            var dropDownPage = new DropDownPage(Driver);
            dropDownPage.Navigate(GlobalTestsSetup.BaseUrl);
            var selectedOption = "Steak";

            // Act
            dropDownPage.SelectFavoriteFoodOption(selectedOption);

            // Assert
            dropDownPage.GetFavoriteFoodSelectedOption().Should().Be(selectedOption);
        }
    }
}
