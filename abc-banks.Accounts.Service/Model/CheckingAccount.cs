using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using abc_bank.Accounts.IService.Model;

namespace abc_bank.Accounts.Service.Model
{
    public class CheckingAccount :BaseAccount, IAccount 
    {
        public CheckingAccount() : base("Checking Account")
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
