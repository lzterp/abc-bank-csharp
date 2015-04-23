﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace abc_bank.Accounts.Common.Model
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
            this.transactionDate = DateProvider.getInstance().Now();
        }
    }
}