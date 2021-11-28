using GameStart.Core.Entities.ShoppingCartAggregate;

namespace GameStart.Endpoints.Orders
{
    public class CreateOrdersRequest : BaseRequest
    {
        public string UserId { get; set; }
        public string Adress { get; set; }
        public List<ShoppingCartItem> cartItem { get; set; }
    }
}