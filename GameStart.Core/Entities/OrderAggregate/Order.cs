using GameStart.Core.Entities.OrderAggregate;
using GameStart.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStart.Core.Entities
{
    public class Order : BaseEntity, IAggregateRoot
    {
        public string UserId { get; private set; }
        public DateTimeOffset date { get; private set; } = DateTimeOffset.Now;
        public string Address { get; private set; }

        private readonly List<OrderItem> _orderItems = new List<OrderItem>();
        public IReadOnlyCollection<OrderItem> OrderItems => _orderItems.AsReadOnly();

        private Order()
        {

        }

        public Order(string userId, string address, List<OrderItem> items)
        {
            UserId = userId;
            Address = address;
            _orderItems = items;
        }

        public decimal Total()
        {
            var total = 0m;
            foreach (var item in _orderItems)
            {
                total += item.UnitPrice * item.Units;
            }
            return total;
        }

    }
}
