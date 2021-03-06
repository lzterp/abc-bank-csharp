﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using abc_bank.Accounts.Common.Models;
using abc_bank.Accounts.IService.Model;
using abc_bank.Accounts.Common.Providers;
using abc_bank.Accounts.Common.Helpers;

namespace abc_bank.Accounts.Service.Model
{
    public class CheckingAccount :BaseAccount, IAccount 
    {
        private List<InterestRule> interestRules;

        public CheckingAccount() : base("Checking Account")
        {
            interestRules = RatesProvider.Instance.GetRates(Common.Constants.AccountType.CHECKING);
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
            InterestEarned += InterestCalculator.CalculateInterest(interestRules, TotalTransactionAmount, transactions, newtranaction.TransactionDate);
            TotalTransactionAmount += newtranaction.amount;

            transactions.Add(newtranaction);
            return TotalTransactionAmount + InterestEarned;
        }

        public double GetInterests()
        {
            return InterestEarned;
        }
    }
}
