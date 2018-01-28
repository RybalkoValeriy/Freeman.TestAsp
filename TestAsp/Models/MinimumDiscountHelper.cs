using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestAsp.Models
{
    public class MinimumDiscountHelper : IDiscountHelper
    {
        // >100 10%
        // 10-100 5$
        // >10 -0
        public decimal ApplyDiscount(decimal totalParam)
        {
            if (totalParam < 0)
            {
                throw new ArgumentOutOfRangeException();
            }
            else if (totalParam > 100)
            {
                return totalParam * 0.9m;
            }
            else if (totalParam >= 10 && totalParam <= 100)
            {
                return totalParam - 5;
            }
            else
            {
                return totalParam;
            }
        }
    }
}