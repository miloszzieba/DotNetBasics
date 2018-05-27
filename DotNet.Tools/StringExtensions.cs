using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNet.Tools
{
    public static class StringExtensions
    {
        public static Decimal ToDecimal(this string s)
        {
            decimal number;

            Decimal.TryParse(s, out number);

            return number;
        }
    }
}
