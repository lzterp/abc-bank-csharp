using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using abc_bank.Accounts.Common.Models;

namespace abc_bank.Accounts.Service.Model
{
    public class BaseAccount
    {
        protected readonly Guid accountid;

        protected double TotalTransactionAmount { get; set; }

        protected double InterestEarned { get; set; }

        protected List<Transaction> transactions;

        public string Description { get; set; }

        public Guid ID { get { return accountid; } }

        public BaseAccount(string description)
        {
            Description = description;
            accountid = new Guid();
            InterestEarned = 0;
            TotalTransactionAmount = 0;
            transactions = new List<Transaction>();
        }
    }
}
