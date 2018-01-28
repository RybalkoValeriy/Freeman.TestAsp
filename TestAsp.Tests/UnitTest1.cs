using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestAsp.Models;
namespace TestAsp.Tests
{
    [TestClass]
    public class UnitTest1
    {
        private IDiscountHelper getTestObject()
        {
            return new MinimumDiscountHelper();
        }

        [TestMethod]
        public void Discount_Above_100()
        {
            // Arrange
            IDiscountHelper target = getTestObject();
            decimal total = 200;
            // Act
            var discountTotal = target.ApplyDiscount(total);
            // Assert
            Assert.AreEqual(total * 0.9M, discountTotal);
        }

        [TestMethod]
        public void Discount_Between_10_And_100()
        {
            // Arrange
            IDiscountHelper target = getTestObject();
            // Act
            decimal TenDollarDiscount = target.ApplyDiscount(10);
            decimal HumdredDollarDiscount = target.ApplyDiscount(100);
            decimal FiftyFollarDiscount = target.ApplyDiscount(50);
            // Assert
            Assert.AreEqual(5, TenDollarDiscount, "$10 discount is wrong");
            Assert.AreEqual(95, HumdredDollarDiscount, "$100 discount is wrong");
            Assert.AreEqual(45, FiftyFollarDiscount, "$10 discount is wrong");
        }

        [TestMethod]
        public void Discount_Less_Than_10()
        {
            // Arrange
            IDiscountHelper target = getTestObject();
            // Act
            decimal discount5 = target.ApplyDiscount(5);
            decimal discount0 = target.ApplyDiscount(0);
            // Assert
            Assert.AreEqual(5, discount5);
            Assert.AreEqual(0, discount0);
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Discount_Negative_Total()
        {
            // Arrange
            IDiscountHelper target = getTestObject();
            // Act
            target.ApplyDiscount(-1);
            // Assert
        }
    }
}
