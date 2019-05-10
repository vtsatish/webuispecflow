using System;
using TechTalk.SpecFlow;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using Xunit;

namespace DemoWebApp.Tests
{
    [Binding]
    public class LoanApplicationTestsSteps
    {
        private IWebDriver _driver;
        private LoanApplicationPage _loanApplicationPage;
        private ApplicationConfirmationPage _applicationConfirmationPage;

        [Given(@"I am on the loan application screen")]
        public void GivenIAmOnTheLoanApplicationScreen()
        {
            _driver = new FirefoxDriver();
            _driver.Manage().Window.Maximize();

            //_driver.Navigate().GoToUrl("http://localhost:40077/Home/StartLoanApplication");

            _loanApplicationPage = new LoanApplicationPage(_driver);
            _loanApplicationPage.Navigate();
        }
        
        [Given(@"I enter a first name of (.*)")]
        public void GivenIEnterAFirstNameOfPerson(String firtsnamearg)
        {
            //IWebElement firstNameInput = _driver.FindElement(By.Id("FirstName"));
            //firstNameInput.SendKeys(firtsnamearg);

            _loanApplicationPage.FirstName = firtsnamearg;
        }
        
        [Given(@"I enter a second name of (.*)")]
        public void GivenIEnterASecondNameOfPerson(String secondnamearg)
        {
            //_driver.FindElement(By.Id("LastName")).SendKeys(secondnamearg);
            _loanApplicationPage.LastName = secondnamearg;  
        }
        
        [Given(@"I select that I have an existing (.*) account")]
        public void GivenISelectThatIHaveAnExistingAccountType(String acconttypearg)
        {
            //if(acconttypearg == "Loan")
            //{
            //    _driver.FindElement(By.Id("Loan")).Click();
            //}
            _loanApplicationPage.SelectAccountType(acconttypearg);

        }
        
        [Given(@"I confirm my acceptance of the terms and conditions")]
        public void GivenIConfirmMyAcceptanceOfTheTermsAndConditions()
        {
            //_driver.FindElement(By.Name("TermsAcceptance")).Click();
            _loanApplicationPage.AcceptTC();
        }
        
        [When(@"I submit my application")]
        public void WhenISubmitMyApplication()
        {
            //_driver.FindElement(By.CssSelector(".btn.btn-primary")).Click();
            _applicationConfirmationPage = _loanApplicationPage.SubmitLoan();
        }
        
        [Then(@"I should see the application complete confirmation for (.*)")]
        public void ThenIShouldSeeTheApplicationCompleteConfirmationForPerosn(String firstnamearg)
        {
            //Assert.Equal(firstnamearg, _driver.FindElement(By.Id("firstName")).Text);
            Assert.Equal(firstnamearg, _applicationConfirmationPage.FirstName);
        }

        [Then(@"I should see error message for not ccepting terms and conditions")]
        public void ThenIShouldSeeErrorMessageForNotCceptingTermsAndConditions()
        {
            //IWebElement errmessage = _driver.FindElement(By.CssSelector("div.validation-summary-errors ul li"));
            //Assert.Equal("You must accept the terms and conditions", errmessage.Text);

            Assert.Equal("You must accept the terms and conditions", _loanApplicationPage.ErrorText);
        }

        [AfterScenario]
        public void cleanup()
        {
            _driver.Dispose();
        }
    }
}
