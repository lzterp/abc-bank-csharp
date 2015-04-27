using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using abc_bank.Accounts.Common.IProviders;

namespace abc_bank.Accounts.Common.Providers
{
    public class DateProvider : IDateProvider
    {

        private static readonly DateProvider instance = new DateProvider();


        static DateProvider()
        {
        }

        private DateProvider()
        {
        }

        public static IDateProvider Instance
        {
            get
            {
                return instance;
            }
        }

        public DateTime Now()
        {
            return DateTime.Now;
        }
    }
}
