using GameStart.Core.Entities.ShoppingCartAggregate;

namespace GameStart.Endpoints.OrderItems
{
    public class CreateOrderItemRequest : BaseRequest
    {
        public ShoppingCartItem shoppingCartItems { get; set; }
    }
}