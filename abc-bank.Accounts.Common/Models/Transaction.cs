using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using abc_bank.Accounts.Common.Providers;

namespace abc_bank.Accounts.Common.Models
{
    public class Transaction
    {
        public readonly double amount;

        public DateTime TransactionDate
        {
            get
            {
                return transactionDate;
            }
        }

        private readonly DateTime transactionDate;

        public Transaction(double amount)
        {
            this.amount = amount;
            this.transactionDate = DateProvider.Instance.Now();
        }
    }
}
