using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using abc_bank;
using abc_bank.Accounts.Common.Models;
using abc_bank.Accounts.Common.IProviders;
using abc_bank_tests.Mocks;

namespace abc_bank_tests
{
    [TestClass]
    public class TransactionTest
    {
        private IDateProvider _dateProvider;

        public TransactionTest()
        {
            _dateProvider = new MockDateProvider();
        }

        [TestMethod]
        public void Transaction()
        {
            Transaction t = new Transaction(_dateProvider, 5);
            //t instanceOf Transaction
            Assert.IsTrue(t.GetType() == typeof(Transaction));
        }
    }
}
