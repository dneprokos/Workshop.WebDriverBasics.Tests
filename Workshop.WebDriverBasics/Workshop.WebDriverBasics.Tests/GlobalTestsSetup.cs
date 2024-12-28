using NUnit.Framework;
using Workshop.WebDriverBasics.Tests.WebDriverCore;

namespace Workshop.WebDriverBasics.Tests
{
    [SetUpFixture]
    public class GlobalTestsSetup
    {
        public static string BaseUrl { get; private set; }

        public static string CredLogin { get; private set; }
               
        public static string CredPassword { get; private set; }
               
        public static string SessionStorageKey { get; private set; }

        public static string SessionStorageValue { get; private set; }

        public static WebDriverOptions BrowserOptions { get; private set; }


        [OneTimeSetUp]
        public void OnceBeforeAllSetup()
        {
            BaseUrl = TestContext.Parameters["baseUrl"]!;
            CredLogin = TestContext.Parameters["login"]!;
            CredPassword = TestContext.Parameters["password"]!;
            SessionStorageKey = TestContext.Parameters["sessionStorageKey"]!;
            SessionStorageValue = TestContext.Parameters["sessionStorageValue"]!;
            BrowserOptions = new WebDriverOptions
            {
                Browser = TestContext.Parameters["browser"]!,
                IsHeadless = bool.Parse(TestContext.Parameters["headless"]!)
            };
        }
    }
}
