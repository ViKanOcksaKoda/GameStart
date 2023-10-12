using GameStart.Core.Entities;
using System;
using Xunit;

namespace UnitTests.GameStartCore.Entities.ProductTests
{
    public class UpdateDetails
    {
        private Product _testItem;
        private int _validCategoryId = 1;
        private string _validDescription = "test description";
        private string _validName = "test name";
        private decimal _validPrice = 1.23m;
        private int _validStockBalance = 5;

        public UpdateDetails()
        {
            _testItem = new Product(_validCategoryId, _validName, _validDescription, _validPrice, _validStockBalance);
        }

        [Fact]
        public void ThrowsArgumentExceptionGivenEmptyName()
        {
            string newValue = "";
            Assert.Throws<ArgumentException>(() => _testItem.UpdateDetails(newValue, _validDescription, _validPrice, _validStockBalance));
        }

        [Fact]
        public void ThrowsArgumentExceptionGivenEmptyDescription()
        {
            string newValue = "";
            Assert.Throws<ArgumentException>(() => _testItem.UpdateDetails(_validName, newValue, _validPrice, _validStockBalance));
        }

        [Fact]
        public void ThrowsArgumentNullExceptionGivenNullName()
        {
            Assert.Throws<ArgumentNullException>(() => _testItem.UpdateDetails(null, _validDescription, _validPrice, _validStockBalance));
        }

        [Fact]
        public void ThrowsArgumentNullExceptionGivenNullDescription()
        {
            Assert.Throws<ArgumentNullException>(() => _testItem.UpdateDetails(_validName, null, _validPrice, _validStockBalance));
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-1.23)]
        public void ThrowsArgumentExceptionGivenNonPositivePrice(decimal newPrice)
        {
            Assert.Throws<ArgumentException>(() => _testItem.UpdateDetails(_validName, _validDescription, newPrice, _validStockBalance));
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-6)]
        public void ThrowsArgumentExceptionGivenNonPositiveStockBalance(int newStockBalance)
        {
            Assert.Throws<ArgumentException>(() => _testItem.UpdateDetails(_validName, _validDescription, _validPrice, newStockBalance));
        }
    }
}
