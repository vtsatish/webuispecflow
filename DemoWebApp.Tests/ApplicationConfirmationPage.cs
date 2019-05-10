using OpenQA.Selenium;

namespace DemoWebApp.Tests
{
    public class ApplicationConfirmationPage
    {
        private IWebDriver _driver;
        public ApplicationConfirmationPage(IWebDriver argdriver)
        {
            _driver = argdriver;
        }
        public string FirstName => _driver.FindElement(By.Id("firstName")).Text;
    }
}