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
        private readonly Guid accountid;

        protected List<Transaction> transactions;

        public string Description { get; set; }

        public Guid ID { get { return accountid; } }

        public BaseAccount(string description)
        {
            Description = description;
            accountid = new Guid();
        }
    }
}
