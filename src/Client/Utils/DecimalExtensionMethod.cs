using System;
using System.Collections.Generic;
using System.Text;

namespace SalesTaxes.Utils
{
    public static class DecimalExtensionMethod
    {
        public static decimal Round(this decimal d)
        {
            var cents = Math.Truncate(((d * 10) - Math.Truncate((d * 10))) * 10);

            if (cents == 0)
                return d;

            if (cents > 5)
                return ((Math.Truncate(d * 10) + 1) / 10);

            return (Math.Truncate(d * 10) / 10) + (decimal).05;
        }
    }
}
