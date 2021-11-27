using GameStart.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStart.Core.Entities.ShoppingCartAggregate
{
    public class ShoppingCartItem : BaseEntity, IAggregateRoot
    {
        public decimal UnitPrice { get; private set; }
        public int Quantity { get; private set; }
        public int ProductId { get; private set; }
        public int ShoppingCartId { get; set; }

        public ShoppingCartItem(int productId, decimal unitPrice, int quantity)
        {
            ProductId = productId;
            UnitPrice = unitPrice;
            SetQuantity(quantity);
        }

        public void AddQuantity(int quantity)
        {
            Quantity += quantity;
        }

        public void SetQuantity(int quantity)
        {
            Quantity = quantity;
        }
    }
}
