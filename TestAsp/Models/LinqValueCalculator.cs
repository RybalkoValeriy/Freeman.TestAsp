using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestAsp.Models
{
    public class LinqValueCalculator : IValueProductCalculator
    {
        private IDiscountHelper discounter;
        public LinqValueCalculator(IDiscountHelper discountHelper)
        {
            discounter = discountHelper;
        }
        public decimal ValueProduct(IEnumerable<Product> products)
        {
            return discounter.ApplyDiscount(products.Sum(p => p.Price));
        }
    }
}