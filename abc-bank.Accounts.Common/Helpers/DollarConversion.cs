using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace abc_bank.Accounts.Common.Helpers
{
    public static class DollarConversion
    {
        public static String ToDollars(double d)
        {
            return String.Format("$%,.2f", Math.Abs(d));
        }

    }
}
