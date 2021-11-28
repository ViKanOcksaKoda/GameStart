using GameStart.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStart.Core.Entities.OrderAggregate
{
    public class OrderItem : BaseEntity, IAggregateRoot
    {
        public decimal UnitPrice { get; private set; }
        public int Units { get; private set; }

        private OrderItem()
        {

        }

        public OrderItem(decimal unitPrice, int units)
        {
            UnitPrice = unitPrice;
            Units = units;
        }
    }
}
