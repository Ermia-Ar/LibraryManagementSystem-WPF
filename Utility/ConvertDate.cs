using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utility
{
    static class ConvertDate
    {
        public static double DateToAmount(DateTime Borrow , DateTime Return)
        {
            var days = Return - Borrow;
            return days.Days * 1.25;
        }
    }
}
