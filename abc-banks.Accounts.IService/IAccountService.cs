using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using abc_banks.Accounts.IService.Model;

namespace abc_banks.Accounts.IService
{
    public interface IAccountService
    {
        IAccount CreateAccount(int AccountTypeid);

    }
}
