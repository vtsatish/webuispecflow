using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace DemoWebApp.Tests
{
    public class LoanApplicationPage
    {
        private IWebDriver _driver;
        private readonly string PageURI = @"http://localhost:40077/Home/StartLoanApplication";
        public LoanApplicationPage(IWebDriver argdriver)
        {
            _driver = argdriver;
        }

        public void Navigate()
        {
            _driver.Navigate().GoToUrl(PageURI);
        }

        public string FirstName
        {
            set
            {
                _driver.FindElement(By.Id("FirstName")).SendKeys(value);
            }
        }

        public string LastName
        {
            set
            {
                _driver.FindElement(By.Id("LastName")).SendKeys(value);
            }
        }

        public string ErrorText => _driver.FindElement(By.CssSelector("div.validation-summary-errors ul li")).Text;

        public void SelectAccountType(string acctype)
        {
            if (acctype == "Loan")
            {
                _driver.FindElement(By.Id("Loan")).Click();
            }
        }

        public void AcceptTC()
        {
            _driver.FindElement(By.Name("TermsAcceptance")).Click();
        }

        public ApplicationConfirmationPage SubmitLoan()
        {
            _driver.FindElement(By.CssSelector(".btn.btn-primary")).Click();
            return new ApplicationConfirmationPage(_driver);
        }
    }
}
