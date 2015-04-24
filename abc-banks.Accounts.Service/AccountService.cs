using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using abc_bank.Accounts.IService;
using abc_bank.Accounts.IService.Model;
using abc_bank.Accounts.Common.Constants;
using abc_bank.Accounts.Common.Models;
using abc_bank.Accounts.Service.Model;

namespace abc_bank.Accounts.Service
{
    public class AccountService : IAccountService
    {

        public IAccount CreateAccount(int AccountTypeid)
        {
            IAccount retacct = null;

            AccountType acctype = (AccountType)AccountTypeid;
            switch (acctype)
            {
                case AccountType.CHECKING:
                    retacct = new CheckingAccount();
                    break;
                case AccountType.MAXI_SAVINGS:
                    retacct = new MaxiAccount();
                    break;
                case AccountType.SAVINGS:
                    retacct = new SavingsAccount();
                    break;
            }

            return retacct;
        }

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

        public String StatementForAccount(IAccount a)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine()


        //Now total up all the transactions
        double total = 0.0;
            foreach (Transaction t in a.transactions) {
                s += "  " + (t.amount< 0 ? "withdrawal" : "deposit") + " " + ToDollars(t.amount) + "\n";
                total += t.amount;
            }
    s += "Total " + ToDollars(total);
            return s;
        }
        
    }

}
