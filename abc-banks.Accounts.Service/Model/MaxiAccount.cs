using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using abc_bank.Accounts.IService.Model;

namespace abc_bank.Accounts.Service.Model
{
    public class MaxiAccount : BaseAccount, IAccount
    {
        public MaxiAccount() : base("Maxi Savings Account")
        {

        }

        string IAccount.Description()
        {
            return this.Description;
        }

        Guid IAccount.ID()
        {
            return this.ID;
        }

        public List<Transaction> GetTransactions()
        {
            return transactions;
        }
    }
}
