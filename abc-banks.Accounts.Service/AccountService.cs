using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using abc_bank.Accounts.IService;
using abc_bank.Accounts.IService.Model;
using abc_bank.Accounts.Common.Constants;
using abc_bank.Accounts.Common.Models;

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

                case MAXI_SAVINGS:

                default:
                 
            }

            return retacct;
        }
    }

}
