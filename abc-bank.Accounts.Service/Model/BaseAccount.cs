using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using abc_bank;

namespace abc_bank.Accounts.Service.Model
{
    public class BaseAccount
    {
        public double Ammount
        {
            get; set;
        } 
        public List<Transaction> transactions;
    }
}
