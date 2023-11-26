using testing_l2.PageObjects;
using testing_l2.Features;
using testing_l2.StepDefinitions;
using testing_l2.Drivers;
using NUnit.Framework;

namespace testing_l2.StepDefinitions
{


    [Binding]
    public sealed class WithdrawStepDefinitions
    {
        private readonly CustomerLoginPageObject customerLoginPageObject;
        private readonly withdraw withdraw;
        private readonly money money;
        private readonly ScenarioContext _scenarioContext;
        private customer Customer;

        public WithdrawStepDefinitions(driver browserDriver, ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
            customerLoginPageObject = new CustomerLoginPageObject(browserDriver.Current);
            withdraw = new withdraw(browserDriver.Current);
            money = new money(browserDriver.Current);
            Customer = new customer();

        }

        [Given(@"Customer with details:(.*),(.*)")]
        public void GivenCustomerWithDetailsNameAmount(string Name, string Amount)
        {
            Customer = new customer(Name, Amount);
        }

        [When(@"I log in as a ""([^""]*)""")]
        public void WhenILogInAsA(string customer)
        {
            customerLoginPageObject.LoginCustomerButton();
            customerLoginPageObject.SelectCustomer(Customer.Name);
            customerLoginPageObject.PressLoginButton();
        }

        [When(@"I navigate to ""([^""]*)"" page")]
        public void WhenINavigateToPage(string Withdraw)
        {
            withdraw.WithdraweButtonClick();
        }

        [When(@"fill the data")]
        public void WhenFillTheData()
        {
            money.SendAmount(Customer.Amount);

        }

        [When(@"I submit the form")]
        public void WhenISubmitTheForm()
        {
            money.SubmitButtonClick();
        }

        [Then(@"Message should be Transaction Successful")]
        public void ThenMessageShouldBeWithdrawSuccessful()
        {
            Assert.IsTrue(money.MessageIsVisible());
        }

        [Then(@"Message shouldn't be displayed")]
        public void ThenNoMessageShouldBeDisplayed()
        {
            Assert.IsTrue(money.MessageIsNotVisible());
        }
        [Then(@"Message should be Transaction Failed\. You can not withdraw amount more than the balance\.")]
        public void ThenMessageShouldBeTransactionFailed_YouCanNotWithdrawAmountMoreThanTheBalance_()
        {
            Assert.IsTrue(money.FailedMessage());
        }

    }
}
