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

namespace abc_bank_tests
{
    [TestClass]
    public class CustomerTest
    {
        private IDateProvider _dateProvider;
        private IAccountService _accountService;

        public CustomerTest()
        {
            _dateProvider = new MockDateProvider();
            _accountService = new AccountService(_dateProvider);
        }

        [TestMethod]
        public void TestApp()
        {

            Customer henry = new Customer("Henry", _accountService);
            IAccount checkingAccount = henry.OpenAccount(AccountType.CHECKING);
            IAccount savingsAccount = henry.OpenAccount(AccountType.SAVINGS);

            _accountService.Deposit(checkingAccount, 100.00);
            _accountService.Deposit(savingsAccount,4000.0);
            _accountService.Withdraw(savingsAccount,200.0);

            Assert.AreEqual("Statement for Henry\n" +
                    "\n" +
                    "Checking Account\n" +
                    "  deposit $100.00\n" +
                    "Total $100.00\n" +
                    "\n" +
                    "Savings Account\n" +
                    "  deposit $4,000.00\n" +
                    "  withdrawal $200.00\n" +
                    "Total $3,800.00\n" +
                    "\n" +
                    "Total In All Accounts $3,900.00", henry.GetStatement());
        }

        [TestMethod]
        public void TestOneAccount()
        {
            Customer oscar = new Customer("Oscar", _accountService);
            var savingsAccount = oscar.OpenAccount(AccountType.SAVINGS);
            Assert.AreEqual(1, oscar.GetNumberOfAccounts());
        }

        [TestMethod]
        public void TestMutilpleAccount()
        {
            Customer oscar = new Customer("Oscar", _accountService);
            oscar.OpenAccount(AccountType.CHECKING);
            oscar.OpenAccount(AccountType.SAVINGS);

            Assert.AreEqual(2, oscar.GetNumberOfAccounts());
        }

        [TestMethod]
        [Ignore]
        public void TestMutilpleAccountWithSameType()
        {
            Customer oscar = new Customer("Oscar", _accountService);
            oscar.OpenAccount(AccountType.CHECKING);
            oscar.OpenAccount(AccountType.SAVINGS);
            oscar.OpenAccount(AccountType.SAVINGS);
            Assert.AreEqual(3, oscar.GetNumberOfAccounts());
        }
    }
}
