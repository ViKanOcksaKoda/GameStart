using Ardalis.GuardClauses;
using GameStart.Core.Interfaces;

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
            Guard.Against.OutOfRange(quantity, nameof(quantity), 0, int.MaxValue);

            Quantity += quantity;
        }

        public void SetQuantity(int quantity)
        {
            Guard.Against.OutOfRange(quantity, nameof(quantity), 0, int.MaxValue);

            Quantity = quantity;
        }
    }
}
