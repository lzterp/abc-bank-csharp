using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using abc_bank.Accounts.IService.Model;
using abc_bank.Accounts.IService;
using abc_bank.Accounts.Service;
using abc_bank.Accounts.Common.Constants;
using abc_bank.Accounts.Common.Helpers;

namespace abc_bank
{
    public class Customer
    {
        private String name;
        private List<IAccount> accounts;
        private IAccountService _accountservice;

        public Customer(String name, IAccountService accountservice)
        {
            this.name = name;
            this.accounts = new List<IAccount>();

            _accountservice = accountservice;
        }

        public String GetName()
        {
            return name;
        }

        public IAccount OpenAccount(AccountType accountTypeId)
        {
            var newacct = _accountservice.CreateAccount(accountTypeId);
            accounts.Add(_accountservice.CreateAccount(accountTypeId));
            return newacct;
        }

        public int GetNumberOfAccounts()
        {
            return accounts.Count;
        }

        public double TotalInterestEarned() 
        {
            double total = 0;
            foreach (IAccount a in accounts)
                total += _accountservice.InterestEarned(a);
            return total;
        }

        public String GetStatement() 
        {
            String statement = null;
            statement = "Statement for " + name + "\n";
            double total = 0.0;
            foreach (IAccount a in accounts) 
            {
                statement += "\n" + _accountservice.StatementForAccount(a) + "\n";
                total += _accountservice.sumTransactions(a);
            }
            statement += "\nTotal In All Accounts " + DollarConversion.ToDollars(total);
            return statement;
        }
    }
}
