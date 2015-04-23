using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace abc_bank.Accounts.Common.Providers
{
    public class DateProvider
    {

        private static readonly DateProvider instance = new DateProvider();


        static DateProvider()
        {
        }

        private DateProvider()
        {
        }

        public static DateProvider Instance
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
