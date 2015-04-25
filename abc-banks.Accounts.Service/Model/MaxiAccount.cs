using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using abc_bank.Accounts.IService.Model;
using abc_bank.Accounts.Common.Models;

namespace abc_bank.Accounts.Service.Model
{
    public class MaxiAccount : BaseAccount, IAccount
    {
        private static double firstInterestRate = 0.02;
        private static double secondInterestRate = 0.05;
        private static double thirdInterestRate = 0.1;

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

        public double AddTransaction(Transaction newtranaction)
        {
            if (TotalAmount <= 1000)
            {
                InterestEarned += TotalAmount * (Math.Pow((1 + Under1kInterestRate / 365), diff) - 1);
                TotalTransactionAmount += newtranaction.amount;
            }
            else
            {
                InterestEarned += (TotalAmount - 1000) * (Math.Pow((1 + Over1kInterestRate / 365), diff) - 1);
                InterestEarned += 1000 * (Math.Pow((1 + Under1kInterestRate / 365), diff) - 1);
                TotalTransactionAmount += newtranaction.amount;
            }
        }
    }
}
