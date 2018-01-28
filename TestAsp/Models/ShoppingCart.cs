using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestAsp.Models
{
    public class ShoppingCart
    {
        private IValueProductCalculator calc;
        public ShoppingCart(IValueProductCalculator calcParam)
        {
            calc = calcParam;
        }

        public IEnumerable<Product> Products { get; set; }

        public decimal CalucateProductTotal()
        {
            return calc.ValueProduct(Products);
        }
    }
}