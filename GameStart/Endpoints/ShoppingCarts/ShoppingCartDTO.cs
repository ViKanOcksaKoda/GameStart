using GameStart.Core.Entities.ShoppingCartAggregate;

namespace GameStart.Endpoints.ShoppingCarts
{
    public class ShoppingCartDTO
    {
        public string UserId { get; set; }
        public int ShoppingCartId { get; set; }
        public List<ShoppingCartItem> ShoppingCartItem  { get; set; }

        public ShoppingCartDTO()
        {
            ShoppingCartItem = new List<ShoppingCartItem>();
        }
    }
}
