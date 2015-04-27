using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using abc_bank.Accounts.IService;
using abc_bank.Accounts.Service;
using abc_bank.Accounts.Common.Constants;
using abc_bank.Accounts.Common.IProviders;
using abc_bank_tests.Mocks;

namespace abc_bank_tests
{
    /// <summary>
    /// Summary description for AccountServiceTest
    /// </summary>
    [TestClass]
    public class AccountServiceTest
    {
        private static readonly double DOUBLE_DELTA = 1e-15;
        private MockDateProvider _dateProvider;

        private IAccountService _accountService;


        public AccountServiceTest()
        {
            _dateProvider = new MockDateProvider();
            _accountService = new AccountService((IDateProvider)_dateProvider);

        }

        [TestMethod]
        public void CheckingAccount()
        {

            var checkingaccount = _accountService.CreateAccount(AccountType.CHECKING);

            _dateProvider.SetMockNow(DateTime.Now.AddDays(-10));
            _accountService.Deposit(checkingaccount, 1000);

            _dateProvider.SetMockNow(DateTime.Now);
            _accountService.Withdraw(checkingaccount, 1000);

            Assert.AreEqual(1000 * (Math.Pow(1 + 0.001, 10) - 1), checkingaccount.GetInterests(), DOUBLE_DELTA);

            Assert.AreEqual("Checking Account", checkingaccount.Description());
        }

        [TestMethod]
        public void Savings_account()
        {
            var savingaccount = _accountService.CreateAccount(AccountType.SAVINGS);

            _dateProvider.SetMockNow(DateTime.Now.AddDays(-10));
            _accountService.Deposit(savingaccount, 2000);

            _dateProvider.SetMockNow(DateTime.Now);
            _accountService.Withdraw(savingaccount, 2000);

            Assert.AreEqual(1000 * (Math.Pow(1 + 0.001, 10) - 1) + 1000 * (Math.Pow(1 + 0.002, 10) - 1), savingaccount.GetInterests(), DOUBLE_DELTA);

            Assert.AreEqual("Savings Account", savingaccount.Description());
        }

        [TestMethod]
        public void Maxi_savings_account()
        {
            var maxiaccount = _accountService.CreateAccount(AccountType.MAXI_SAVINGS);

            _dateProvider.SetMockNow(DateTime.Now.AddDays(-20));
            _accountService.Deposit(maxiaccount, 2000);
            _accountService.Withdraw(maxiaccount, 1000);

            _dateProvider.SetMockNow(DateTime.Now);
            _accountService.Withdraw(maxiaccount, 1000);

            Assert.AreEqual((1000 * (Math.Pow(1 + 0.001, 10) - 1) + 1000) * (Math.Pow(1 + 0.05, 10) - 1) + 1000 * (Math.Pow(1 + 0.001, 10) - 1), maxiaccount.GetInterests(), DOUBLE_DELTA);

            Assert.AreEqual("Maxi Savings Account", maxiaccount.Description());
        }
    }
}
