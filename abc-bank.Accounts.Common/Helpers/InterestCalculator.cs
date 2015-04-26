using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using abc_bank.Accounts.Common.Models;

namespace abc_bank.Accounts.Common.Helpers
{
    public static class InterestCalculator
    {
        /// <summary>
        /// Recursively calculates the interst based on last transaction date, and interest rules
        /// </summary>
        /// <param name="rules"></param>
        /// <param name="baseAmount"></param>
        /// <param name="trans"></param>
        /// <returns></returns>
        public static double CalculateInterest(List<InterestRule> rules, double baseAmount, List<Transaction> trans)
        {
            double interest = 0;
            DateTime lastTransactionDate;
            DateTime lastWithDrawDate;

            if (trans != null && trans.Count > 0)
            {
                lastTransactionDate = trans.Max(x => x.TransactionDate);

                var withdraws = trans.Where(x => x.amount < 0);
                if (withdraws != null && withdraws.Any())
                {
                    lastWithDrawDate = withdraws.Max(x => x.TransactionDate);                  
                }
                else
                {
                    lastWithDrawDate = DateTime.Now;
                }
            }
            else
            {
                lastTransactionDate = DateTime.Now;
                lastWithDrawDate = DateTime.Now;
            }

            interest = RecursiveInterstAdd(rules, baseAmount, lastTransactionDate, lastWithDrawDate);

            return interest;
        }

        private static double RecursiveInterstAdd(List<InterestRule> rules, double baseAmount,  DateTime lastTransactionDate, DateTime lastWithDrawDate)
        {
            if (baseAmount > 0 && rules != null && rules.Count > 0)
            {
                var rule = rules.OrderBy(x => x.Order).First();
                if (rule.type == Constants.RuleType.AmountLimit)
                {
                    if (baseAmount < rule.RuleValue)
                    {
                        return InterestRateFunction(baseAmount, DayDiffCalculator.GetDayDiff(lastTransactionDate, DateTime.Now), rule.Rate);
                    }
                    else
                    {
                        var interest = InterestRateFunction(rule.RuleValue, DayDiffCalculator.GetDayDiff(lastTransactionDate, DateTime.Now), rule.Rate);

                        return interest + RecursiveInterstAdd(rules.Where(x=> x.Order != rule.Order).ToList(), baseAmount-rule.RuleValue, lastTransactionDate, lastWithDrawDate);
                    }
                }
                else if(rule.type == Constants.RuleType.WithDrawSpan)
                {
                    var postwithdrawandtransactiongapdays = DayDiffCalculator.GetDayDiff(lastWithDrawDate, lastTransactionDate);
                    var dayssincelastwithdraw = DayDiffCalculator.GetDayDiff(lastWithDrawDate, DateTime.Now);
                    var dayssincelasttransaction = DayDiffCalculator.GetDayDiff(lastTransactionDate, DateTime.Now);

                    //last transaction was withdraw
                    if (postwithdrawandtransactiongapdays == 0)
                    {
                        if(dayssincelasttransaction <rule.RuleValue)
                        {
                            return InterestRateFunction(baseAmount, dayssincelasttransaction , rule.Rate);
                        }
                        else
                        {
                            return InterestRateFunction(baseAmount, rule.RuleValue, rule.Rate) 
                                + RecursiveInterstAdd(rules.Where(x => x.Order != rule.Order).ToList(), baseAmount, lastTransactionDate.AddDays(rule.RuleValue),  lastWithDrawDate);
                        }
                    }
                    // last transaction was out of post withdraw interest deduction range
                    else if (postwithdrawandtransactiongapdays >= rule.RuleValue)
                    {
                        return RecursiveInterstAdd(rules.Where(x => x.Order != rule.Order).ToList(), baseAmount, lastTransactionDate, lastWithDrawDate);
                    }
                    // last transaction was within post withdraw interest deduction range
                    else
                    {
                        var partialreductiondays = rule.RuleValue - postwithdrawandtransactiongapdays;
                        if (dayssincelasttransaction < partialreductiondays)
                        {
                            return InterestRateFunction(baseAmount, dayssincelasttransaction, rule.Rate);
                        }
                        else
                        {
                            return InterestRateFunction(baseAmount, partialreductiondays, rule.Rate)
                                + RecursiveInterstAdd(rules.Where(x => x.Order != rule.Order).ToList(), baseAmount, lastTransactionDate.AddDays(partialreductiondays), lastWithDrawDate);
                        }
                    }

                }
            }

            return 0;
        }

        private static double InterestRateFunction(double baseAmount, double times, double annualrate)
        {
            return baseAmount * (Math.Pow((1 + annualrate / 365), times) - 1);
        }

    }
}
