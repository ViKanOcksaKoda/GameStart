using GameStart.Core.Entities.ShoppingCartAggregate;
using System;
using System.Linq;
using Xunit;

namespace UnitTests.GameStartCore.Entities.ShoppingCartTests
{
    public class ShoppingCartAddItem
    {
        private readonly int _testProductId = 123;
        private readonly decimal _testUnitPrice = 1.23m;
        private readonly int _testQuantity = 2;
        private readonly string _userId = "Test userId";

        [Fact]
        public void AddsBasketItemIfNotPresent()
        {
            var shoppingCart = new ShoppingCart(_userId);
            shoppingCart.AddItem(_testProductId, _testUnitPrice, _testQuantity);

            var firstItem = shoppingCart.Items.Single();
            Assert.Equal(_testProductId, firstItem.ProductId);
            Assert.Equal(_testUnitPrice, firstItem.UnitPrice);
            Assert.Equal(_testQuantity, firstItem.Quantity);
        }

        [Fact]
        public void IncrementsQuantityOfItemIfPresent()
        {
            var basket = new ShoppingCart(_userId);
            basket.AddItem(_testProductId, _testUnitPrice, _testQuantity);
            basket.AddItem(_testProductId, _testUnitPrice, _testQuantity);

            var firstItem = basket.Items.Single();
            Assert.Equal(_testQuantity * 2, firstItem.Quantity);
        }

        [Fact]
        public void KeepsOriginalUnitPriceIfMoreItemsAdded()
        {
            var basket = new ShoppingCart(_userId);
            basket.AddItem(_testProductId, _testUnitPrice, _testQuantity);
            basket.AddItem(_testProductId, _testUnitPrice * 2, _testQuantity);

            var firstItem = basket.Items.Single();
            Assert.Equal(_testUnitPrice, firstItem.UnitPrice);
        }

        [Fact]
        public void DefaultsToQuantityOfOne()
        {
            var basket = new ShoppingCart(_userId);
            basket.AddItem(_testProductId, _testUnitPrice);

            var firstItem = basket.Items.Single();
            Assert.Equal(1, firstItem.Quantity);
        }

        [Fact]
        public void CantAddItemWithNegativeQuantity()
        {
            var shoppingCart = new ShoppingCart(_userId);

            Assert.Throws<ArgumentOutOfRangeException>(() => shoppingCart.AddItem(_testProductId, _testUnitPrice, -1));
        }

        [Fact]
        public void CantModifyQuantityToNegativeNumber()
        {
            var shoppingCart = new ShoppingCart(_userId);
            shoppingCart.AddItem(_testProductId, _testUnitPrice);

            Assert.Throws<ArgumentOutOfRangeException>(() => shoppingCart.AddItem(_testProductId, _testUnitPrice, -2));
        }
    }
}
