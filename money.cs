using OpenQA.Selenium;
using OpenQA.Selenium.Internal;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System.Linq.Expressions;
using System.Threading;

namespace testing_l2.PageObjects
{
    internal class money
    {
        private IWebDriver webDriver;

        public money(IWebDriver web) { webDriver = web; }
        private readonly string AmountInputXPath = "/html/body/div/div/div[2]/div/div[4]/div/form/div/input";
        private IWebElement AmountInputObject => webDriver.FindElement(By.XPath(AmountInputXPath));

        public void SendAmount(string amount) { AmountInputObject.SendKeys(amount); Thread.Sleep(1000); }


        private readonly string SubmitButtonXPath = "/html/body/div/div/div[2]/div/div[4]/div/form/button";
        private IWebElement SubmitButton => webDriver.FindElement(By.XPath(SubmitButtonXPath));
        public void SubmitButtonClick() { SubmitButton.Click(); Thread.Sleep(1000); }


        private readonly string MessageXPath = "/html/body/div/div/div[2]/div/div[4]/div/span";
        private IWebElement MessageObject => webDriver.FindElement(By.XPath(AmountInputXPath));

        public bool MessageIsVisible()
        {
            try
            {
                var wait = new WebDriverWait(webDriver, TimeSpan.FromSeconds(3));
                var element = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(MessageXPath)));
                switch (element.Text)
                {
                    case "Transaction successful": return true;
                    case "Transaction Failed. You can not withdraw amount more than the balance.": return false;
                    default: break;
                }
                return element.Displayed;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
            catch (WebDriverTimeoutException)
            {
                return false;
            }
        }
        public bool MessageIsNotVisible()
        {
            try
            {
                var wait = new WebDriverWait(webDriver, TimeSpan.FromSeconds(3));
                var element = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(MessageXPath)));
                switch (element.Text)
                {
                    case "Transaction successful": return false;
                    case "Transaction Failed. You can not withdraw amount more than the balance.": return false;
                    default: break;
                }
                return !element.Displayed;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
            catch (WebDriverTimeoutException)
            {
                return true;
            }
        }
        public bool FailedMessage()
        {
            try
            {
                var wait = new WebDriverWait(webDriver, TimeSpan.FromSeconds(3));
                var element = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(MessageXPath)));
                switch (element.Text)
                {
                    case "Transaction successful": return false;
                    case "Transaction Failed. You can not withdraw amount more than the balance.": return true;
                    default: break;
                }
                return element.Displayed;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
            catch (WebDriverTimeoutException)
            {
                return false;
            }
        }



    }
}
