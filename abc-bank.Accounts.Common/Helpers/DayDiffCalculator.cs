using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace abc_bank.Accounts.Common.Helpers
{
    public static class DayDiffCalculator
    {
        public static int GetDayDiff(DateTime beforedate, DateTime afterdate)
        {
            TimeSpan age = afterdate.Date.Subtract(beforedate.Date);
            Int32 diff = Convert.ToInt32(age.TotalDays);

            return diff;
        }
    }
}
