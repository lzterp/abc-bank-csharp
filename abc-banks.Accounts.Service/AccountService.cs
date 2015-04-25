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
using abc_bank.Accounts.Common.Helpers;

namespace abc_bank.Accounts.Service
{
    public class AccountService : IAccountService
    {

        public IAccount CreateAccount(AccountType accountTypeid)
        {
            IAccount retacct = null;

            switch (accountTypeid)
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

        public void Deposit(IAccount a, double amount)
        {
            if (amount > 0)
            {
                a.AddTransaction(new Transaction(amount));
            }
            else throw new Exception("amount must be positive");
        }

        public double InterestEarned(IAccount a)
        {
            return 
        }

        public double sumTransactions(IAccount a)
        {
           var alltransaction = a.GetTransactions();
            if (alltransaction != null & alltransaction.Any())
            {
                return alltransaction.Sum(x => x.amount);
            }
            else return 0;
      
        }

        public void Withdraw(IAccount a, double amount)
        {
            if (amount > 0)
            {
                a.AddTransaction(new Transaction(-amount));
            }
            else throw new Exception("amount must be positive");
        }

        public String StatementForAccount(IAccount a)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(a.Description());


        //Now total up all the transactions
        double total = 0.0;
            foreach (Transaction t in a.GetTransactions()) {
                sb.AppendLine("  ").Append(t.amount< 0 ? "withdrawal" : "deposit").Append(" ").Append(DollarConversion.ToDollars(t.amount));
                total += t.amount;
            }
    sb.Append("Total ").Append(DollarConversion.ToDollars(total));
            return sb.ToString();
        }
        
    }

}
