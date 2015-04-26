using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using abc_bank.Accounts.Common.Constants;
using abc_bank.Accounts.Common.Models;

namespace abc_bank.Accounts.Common.Providers
{
    public class RatesProvider
    {
        private static readonly RatesProvider instance = new RatesProvider();
        private static List<InterestRule> rules;

        static RatesProvider()
        {
        }

        private RatesProvider()
        {
        }

        public static RatesProvider Instance
        {
            get
            {
                rules = InitRates();
                return instance;
            }
        }

        public List<InterestRule>  GetRates(AccountType acctype)
        {
            return rules.Where(x => x.accountType == acctype).ToList();

        }

        //this can be hooked to a Database for dynamic rates change
        private static List<InterestRule> InitRates()
        {
            List<InterestRule> rules = new List<InterestRule>();

            var rule1 = new InterestRule();
            rule1.Order = 1;
            rule1.Rate = 0.001;
            rule1.type = RuleType.AmountLimit;
            rule1.RuleValue = double.MaxValue;
            rule1.accountType = AccountType.CHECKING;
            rules.Add(rule1);

            var rule2 = new InterestRule();
            rule2.Order = 1;
            rule2.Rate = 0.001;
            rule2.type = RuleType.AmountLimit;
            rule2.RuleValue = 1000;
            rule2.accountType = AccountType.SAVINGS;
            rules.Add(rule2);

            var rule3 = new InterestRule();
            rule3.Order = 2;
            rule3.Rate = 0.002;
            rule3.type = RuleType.AmountLimit;
            rule3.RuleValue = double.MaxValue;
            rule3.accountType = AccountType.SAVINGS;
            rules.Add(rule3);

            var rule4 = new InterestRule();
            rule4.Order = 1;
            rule4.Rate = 0.001;
            rule4.type = RuleType.WithDrawSpan;
            rule4.RuleValue = 10;
            rule4.accountType = AccountType.MAXI_SAVINGS;
            rules.Add(rule4);

            var rule5 = new InterestRule();
            rule5.Order = 2;
            rule5.Rate = 0.05;
            rule5.type = RuleType.AmountLimit;
            rule5.RuleValue = double.MaxValue;
            rule5.accountType = AccountType.MAXI_SAVINGS;
            rules.Add(rule5);

            return rules;
        }

    }
}
