using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using abc_bank.Accounts.IService.Model;

namespace abc_bank.Accounts.Service.Model
{
    public class SavingsAccount : BaseAccount, IAccount
    {
        public void Deposit(double amount)
        {
            throw new NotImplementedException();
        }

        public double InterestEarned()
        {
            throw new NotImplementedException();
        }

        public double sumTransactions()
        {
            throw new NotImplementedException();
        }

        public void Withdraw(double amount)
        {
            throw new NotImplementedException();
        }
    }
}
