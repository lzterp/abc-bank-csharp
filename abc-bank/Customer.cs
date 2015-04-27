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
        private List<IAccount> _accounts;
        private IAccountService _accountservice;

        public Customer(String name, IAccountService accountservice)
        {
            this.name = name;
            this._accounts = new List<IAccount>();

            _accountservice = accountservice;
        }

        public String GetName()
        {
            return name;
        }

        public IAccount OpenAccount(AccountType accountTypeId)
        {
            var newacct = _accountservice.CreateAccount(accountTypeId);
            _accounts.Add(_accountservice.CreateAccount(accountTypeId));
            return newacct;
        }

        public int GetNumberOfAccounts()
        {
            return _accounts.Count;
        }

        public double TotalInterestEarned() 
        {
            double total = 0;
            foreach (IAccount a in _accounts)
                total += _accountservice.InterestEarned(a);
            return total;
        }

        public String GetStatement() 
        {
            String statement = null;
            statement = "Statement for " + name + "\n";
            double total = 0.0;
            foreach (IAccount a in _accounts) 
            {
                statement += "\n" + _accountservice.StatementForAccount(a) + "\n";
                total += _accountservice.sumTransactions(a);
            }
            statement += "\nTotal In All Accounts " + DollarConversion.ToDollars(total);
            return statement;
        }

        public List<IAccount> AllAccounts()
        {
            return _accounts;
        }

        public bool Withdraw(Guid ID, double amount)
        {
            var foundaccount = _accounts.Where(x => x.ID() == ID).FirstOrDefault();
            _accounts.Remove(foundaccount);
            _accountservice.Withdraw(foundaccount, amount);
            _accounts.Add(foundaccount);
            return true;
        }

        public bool Deposit(Guid ID, double amount)
        {
            var foundaccount = _accounts.Where(x => x.ID() == ID).FirstOrDefault();
            _accounts.Remove(foundaccount);
            _accountservice.Deposit(foundaccount, amount);
            _accounts.Add(foundaccount);
            return true;
        }
    }
}
