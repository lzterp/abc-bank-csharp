using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using abc_bank.Accounts.Common.Constants;

namespace abc_bank.Accounts.Common.Models
{
    public class InterestRule
    {
        public double Rate { get; set; }

        public double RuleValue { get; set; }

        public int Order { get; set; }

        public RuleType type { get; set; }

        public AccountType accountType { get; set; }
    }
}
