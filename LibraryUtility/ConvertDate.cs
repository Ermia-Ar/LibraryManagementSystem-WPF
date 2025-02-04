using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryUtility
{
    public static class ConvertDate
    {
        public static double DateToAmount(DateTime due , DateTime Return)
        {
            var days = Return - due;
            return days.Days > 0 ? days.Days * 1.25 : 00;
        }
    }
}
