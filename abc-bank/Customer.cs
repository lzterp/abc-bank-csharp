using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using abc_bank.Accounts.IService.Model;
using abc_bank.Accounts.IService;
using abc_bank.Accounts.Service;

namespace abc_bank
{
    public class Customer
    {
        private String name;
        private List<IAccount> accounts;
        private IAccountService _accountservice;

        public Customer(String name)
        {
            this.name = name;
            this.accounts = new List<IAccount>();

            _accountservice = new AccountService();
        }

        public String GetName()
        {
            return name;
        }

        public Customer OpenAccount(int AccountTypeId)
        {
            accounts.Add(_accountservice.CreateAccount(AccountTypeId));
            return this;
        }

        public int GetNumberOfAccounts()
        {
            return accounts.Count;
        }

        public double TotalInterestEarned() 
        {
            double total = 0;
            foreach (IAccount a in accounts)
                total += a.InterestEarned();
            return total;
        }

        public String GetStatement() 
        {
            String statement = null;
            statement = "Statement for " + name + "\n";
            double total = 0.0;
            foreach (IAccount a in accounts) 
            {
                statement += "\n" + statementForAccount(a) + "\n";
                total += a.sumTransactions();
            }
            statement += "\nTotal In All Accounts " + ToDollars(total);
            return statement;
        }

        private String ToDollars(double d)
        {
            return String.Format("$%,.2f", Math.Abs(d));
        }
    }
}
