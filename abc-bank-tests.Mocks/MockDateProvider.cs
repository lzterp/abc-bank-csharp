using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using abc_bank.Accounts.Common;
using abc_bank.Accounts.Common.IProviders;

namespace abc_bank_tests.Mocks
{
    public class MockDateProvider : IDateProvider
    {
        private DateTime mocknow = DateTime.Now;

        public void SetMockNow(DateTime newnow)
        {
            mocknow = newnow;
        }

        public DateTime Now()
        {
            return mocknow;
        }
    }
}
