using System.Collections.Generic;

namespace TestAsp.Models
{
    public interface IValueProductCalculator
    {
        decimal ValueProduct(IEnumerable<Product> products);
    }
}