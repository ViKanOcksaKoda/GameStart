using GameStart.Core.Entities;
using GameStart.Core.Entities.OrderAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTests.Builders
{
    public class OrderBuilder
    {
        private Order _order;
        public string TestUserId => "12345";
        public int TestProductId => 234;
        public string TestProductName => "Test Product Name";
        public string TestAddress => "Test Address";
        public decimal TestUnitPrice = 1.23m;
        public int TestUnits = 3;

        public OrderBuilder()
        {
            _order = WithDefaultValues();
        }

        public Order Build()
        {
            return _order;
        }

        public Order WithDefaultValues()
        {
            var orderItem = new OrderItem(TestUnitPrice, TestUnits);
            var itemList = new List<OrderItem>() { orderItem };
            _order = new Order(TestUserId, TestAddress,  itemList);
            return _order;
        }

        public Order WithNoItems()
        {
            _order = new Order(TestUserId, TestAddress, new List<OrderItem>());
            return _order;
        }

        public Order WithItems(List<OrderItem> items)
        {
            _order = new Order(TestUserId, TestAddress, items);
            return _order;
        }
    }
}
