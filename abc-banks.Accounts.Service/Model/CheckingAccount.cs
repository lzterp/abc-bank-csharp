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

        public void Deposit(double amount)
        {
            throw new NotImplementedException();
        }

    }
}
