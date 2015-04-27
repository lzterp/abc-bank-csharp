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

        private IDateProvider _dateProvider;

        private IAccountService GetAccountService()
        {
            return new AccountService();
        }

        public AccountServiceTest()
        {
            _dateProvider = new MockDateProvider();

        }

        [TestMethod]
        public void CheckingAccount()
        {
            var checkingaccount = GetAccountService().CreateAccount(AccountType.CHECKING);

            Assert.AreEqual("Checking Account", checkingaccount.Description());
        }

        [TestMethod]
        public void OSavings_account()
        {
            var checkingaccount = GetAccountService().CreateAccount(AccountType.SAVINGS);

            Assert.AreEqual("Savings Account", checkingaccount.Description());
        }

        [TestMethod]
        public void Maxi_savings_account()
        {
            var checkingaccount = GetAccountService().CreateAccount(AccountType.MAXI_SAVINGS);

            Assert.AreEqual("Maxi Savings Account", checkingaccount.Description());
        }
    }
}
