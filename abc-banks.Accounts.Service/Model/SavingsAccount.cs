using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using abc_bank.Accounts.Common.Models;
using abc_bank.Accounts.IService.Model;

namespace abc_bank.Accounts.Service.Model
{
    public class SavingsAccount : BaseAccount, IAccount
    {

        private static double Under1kInterestRate = 0.001;
        private static double Over1kInterestRate = 0.002;

        public SavingsAccount() : base("Savings Account")
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
            DateTime newDate = Convert.ToDateTime(newtranaction.TransactionDate).Date;
            DateTime LastTransactionDate = transactions.Max(x => x.TransactionDate).Date;
            double TotalAmount = TotalTransactionAmount + InterestEarned;

            TimeSpan age = newDate.Subtract(LastTransactionDate);
            Int32 diff = Convert.ToInt32(age.TotalDays);

            if (TotalAmount <= 1000)
            {
                InterestEarned += TotalAmount * (Math.Pow((1 + Under1kInterestRate / 365), diff) - 1);
                TotalTransactionAmount += newtranaction.amount;
            }
            else
            {
                InterestEarned += (TotalAmount-1000) * (Math.Pow((1 + Over1kInterestRate / 365), diff) - 1);
                InterestEarned += 1000 * (Math.Pow((1 + Under1kInterestRate / 365), diff) - 1);
                TotalTransactionAmount += newtranaction.amount;
            }


            transactions.Add(newtranaction);
            return TotalTransactionAmount + InterestEarned;
        }
    }
}
