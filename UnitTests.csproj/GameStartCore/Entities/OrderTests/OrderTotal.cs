using GameStart.Core.Entities.OrderAggregate;
using System.Collections.Generic;
using UnitTests.Builders;
using Xunit;

namespace UnitTests.GameStartCore.Entities.OrderTests
{
    public class OrderTotal
    {
        private decimal _testUnitPrice = 58m;

        [Fact]
        public void IsZeroForNewOrder()
        {
            var order = new OrderBuilder().WithNoItems();

            Assert.Equal(0, order.Total());
        }

        [Fact]
        public void IsCorrectGiven1Item()
        {
            var items = new List<OrderItem>
            {
                new OrderItem( _testUnitPrice, 1)
            };
            var order = new OrderBuilder().WithItems(items);
            Assert.Equal(_testUnitPrice, order.Total());
        }

        [Fact]
        public void IsCorrectGiven3Items()
        {
            var builder = new OrderBuilder();
            var order = builder.WithDefaultValues();

            Assert.Equal(builder.TestUnitPrice * builder.TestUnits, order.Total());
        }
    }
}
