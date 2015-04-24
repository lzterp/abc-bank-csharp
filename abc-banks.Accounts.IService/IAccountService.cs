using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using abc_bank.Accounts.IService.Model;
using abc_bank.Accounts.Common.Constants;

namespace abc_bank.Accounts.IService
{
    public interface IAccountService
    {
        IAccount CreateAccount(AccountType accountTypeid);

        String StatementForAccount(IAccount a);

        void Deposit(double amount);


        double InterestEarned();

        double sumTransactions();

        void Withdraw(double amount);
    }
}
