using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestAsp.Models
{
    public class DefaultDiscountHelper : IDiscountHelper
    {
        public decimal DiscountSize { get; set; }
        public decimal ApplyDiscount(decimal totalparam)
        {
            return (totalparam - (DiscountSize / 100m * totalparam));
        }
    }
}