using GameStart.Core.Entities.ShoppingCartAggregate;
using GameStart.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStart.Core.Entities.ShoppingCartAggregate
{
    public class ShoppingCart : BaseEntity, IAggregateRoot
    {
        public string UserId { get; private set; }
        private readonly List<ShoppingCartItem> _items = new List<ShoppingCartItem>();
        public IReadOnlyCollection<ShoppingCartItem> Items  => _items.AsReadOnly();

        public ShoppingCart(string userId)
        {
            UserId = userId;
        }

        public void AddItem(int productId, decimal unitPrice, int quantity = 1)
        {
            if (!Items.Any(i => i.ProductId == productId))
            {
                _items.Add(new ShoppingCartItem(productId, unitPrice, quantity));
                return;
            }
            var existingItem = Items.First(i => i.ProductId == productId);
            existingItem.AddQuantity(quantity);
        }

        public void RemoveEmptyItems()
        {
            _items.RemoveAll(i => i.Quantity == 0);
        }
    }
}
