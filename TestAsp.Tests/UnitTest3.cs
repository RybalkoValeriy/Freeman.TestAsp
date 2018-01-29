using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using TestAsp.Models;
namespace TestAsp.Tests
{
    [TestClass]
    public class UnitTest3
    {
        private Product[] products ={
            new Product {Name = "Kayak", Category = "Watersports", Price = 275M},
            new Product {Name = "Lifejacket", Category = "Watersports", Price = 48.95M},
            new Product {Name = "Soccer ball", Category = "Soccer", Price = 19.50M},
            new Product {Name = "Corner flag", Category = "Soccer", Price = 34.95M}
        };

        [TestMethod]
        public void Sum_Products_Correctly()
        {
            // Arrange
            Mock<IDiscountHelper> mock = new Mock<IDiscountHelper>();
            mock.Setup(m => m.ApplyDiscount(It.IsAny<decimal>())).Returns<decimal>(total => total);
            var target = new LinqValueCalculator(mock.Object);
            // Act
            var result = target.ValueProduct(products);
            // Assert
            Assert.AreEqual(products.Sum(e => e.Price), result);
        }

        public Product[] CreateNewProductsSetPrice(decimal priceParamProduct)
        {
            return new Product[]
                {
                    new Product
                    { Price = priceParamProduct}
                };
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException),"exeption argumet")]
        public void Pass_Throungh_Variable_Discount()
        {
            // Arrange
            Mock<IDiscountHelper> mock = new Mock<IDiscountHelper>();

            mock.Setup(m => m.ApplyDiscount(It.IsAny<decimal>()))
                .Returns<decimal>(total => total);

            mock.Setup(m => m.ApplyDiscount(It.Is<decimal>(v => v == 0)))
                .Throws<System.ArgumentOutOfRangeException>();

            mock.Setup(m => m.ApplyDiscount(It.Is<decimal>(v => v > 100)))
                .Returns<decimal>(total => total * 0.9M);

            mock.Setup(m => m.ApplyDiscount(It.IsInRange<decimal>(10, 100, Range.Inclusive))).Returns<decimal>(total => total - 5);

            var target = new LinqValueCalculator(mock.Object);
            // Act
            decimal doolars100 = target.ValueProduct(CreateNewProductsSetPrice(100));
            decimal dollars0 = target.ValueProduct(CreateNewProductsSetPrice(0));
            decimal dollars10 = target.ValueProduct(CreateNewProductsSetPrice(10));
            decimal dollars500 = target.ValueProduct(CreateNewProductsSetPrice(500));
            decimal dollars5 = target.ValueProduct(CreateNewProductsSetPrice(5));
            // Assert
            Assert.AreEqual(95, doolars100, "fail100$");
            Assert.AreEqual(0, dollars0, "exeption 0$");
            Assert.AreEqual(5, dollars10, "fail 10$");
            Assert.AreEqual(5, dollars5, "fail 5$");
            Assert.AreEqual(500, dollars500, "fail 500$");
            target.ValueProduct(CreateNewProductsSetPrice(0));
        }

    }
}
