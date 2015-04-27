using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using abc_bank.Accounts.IService.Model;
using abc_bank.Accounts.Common.Constants;
using abc_bank.Accounts.Common.IProviders;

namespace abc_bank.Accounts.IService
{
    public interface IAccountService
    {
        IAccount CreateAccount(AccountType accountTypeid);

        String StatementForAccount(IAccount a);

        void Deposit(IAccount a, double amount);


        double InterestEarned(IAccount a);

        double sumTransactions(IAccount a);

        void Withdraw(IAccount a, double amount);
    }
}
