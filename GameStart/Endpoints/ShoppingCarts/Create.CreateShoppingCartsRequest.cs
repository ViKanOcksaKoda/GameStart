using GameStart.Core.Entities;
using GameStart.Core.Entities.ShoppingCartAggregate;

namespace GameStart.Endpoints.ShoppingCarts
{
    public class CreateShoppingCartsRequest : BaseRequest
    {
        public string UserId { get; set; }
        public List<ShoppingCartItem> ShoppingCartItem { get; set; }
    }
}