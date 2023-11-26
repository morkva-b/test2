using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace testing_l2.PageObjects
{
    internal class CustomerLoginPageObject
    {
        private IWebDriver webDriver;

        public CustomerLoginPageObject(IWebDriver web) { webDriver = web; }
        private readonly string loginCustomerButtonPageXPath = "//html/body/div/div/div[2]/div/div[1]/div[1]/button";

        private IWebElement LoginCustomerButtonPage => webDriver.FindElement(By.XPath(loginCustomerButtonPageXPath));
        public void LoginCustomerButton()
        {
            LoginCustomerButtonPage.Click();
            Thread.Sleep(500);
        }
        // логін по юзеру(1)  , сабміт на кнопку логін(2)


        private readonly string CustomerSelectorXPath = "/html/body/div/div/div[2]/div/form/div/select";

        private IWebElement CustomerSelectorObject => webDriver.FindElement(By.XPath(CustomerSelectorXPath));
        private SelectElement selectCustomer => new SelectElement(CustomerSelectorObject);

        public void SelectCustomer(string customerName)
        {
            Thread.Sleep(1000);
            selectCustomer.SelectByText(customerName);
            Thread.Sleep(1000);
        }

        private readonly string LoginCustomerButtonXPath = "//html/body/div/div/div[2]/div/form/button";
        private IWebElement LoginButton => webDriver.FindElement(By.XPath(LoginCustomerButtonXPath));

        public void PressLoginButton()
        {
            LoginButton.Click();
            Thread.Sleep(1000);
        }


    }
}