using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace testing_l2.PageObjects
{
    internal class withdraw
    {
        private IWebDriver webDriver;

        public withdraw(IWebDriver web) { webDriver = web; }
        private readonly string WithdraweButtonXPath = "/html/body/div/div/div[2]/div/div[3]/button[3]";
        private IWebElement WithdraweButton => webDriver.FindElement(By.XPath(WithdraweButtonXPath));
        public void WithdraweButtonClick()
        {
            Thread.Sleep(1000);
            WithdraweButton.Click();
            Thread.Sleep(1000);
        }
    }
}
