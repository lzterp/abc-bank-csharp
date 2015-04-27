using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using abc_bank;
using abc_bank.Accounts.IService.Model;
using abc_bank.Accounts.IService;
using abc_bank.Accounts.Service;
using abc_bank.Accounts.Service.Model;
using abc_bank.Accounts.Common;
using abc_bank.Accounts.Common.Constants;
using abc_bank.Accounts.Common.IProviders;
using abc_bank_tests.Mocks;
using Telerik.JustMock;

namespace abc_bank_tests
{
    [TestClass]
    public class BankTest
    {

        private IDateProvider _dateProvider;
        private IAccountService _accountService;


        public BankTest()
        {
            _dateProvider = new MockDateProvider();
            _accountService = Mock.Create<IAccountService>();
        } 


        [TestMethod]
        public void CustomerSummary() 
        {
            Bank bank = new Bank();

            Mock.Arrange(() => _accountService.CreateAccount(AccountType.CHECKING)).Returns(new CheckingAccount());

            Customer john = new Customer("John", _accountService);
            john.OpenAccount(AccountType.CHECKING);
            bank.AddCustomer(john);

            Assert.AreEqual("Customer Summary\n - John (1 account)", bank.CustomerSummary());
        }


    }
}
