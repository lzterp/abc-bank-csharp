using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using abc_bank.Accounts.Common.Models;

namespace abc_bank.Accounts.Service.Model
{
    public class BaseAccount
    {
        protected List<Transaction> transactions;
    }
}
