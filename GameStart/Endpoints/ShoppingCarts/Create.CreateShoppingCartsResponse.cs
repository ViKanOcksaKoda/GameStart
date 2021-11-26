using GameStart.Core.Entities.ShoppingCartAggregate;

namespace GameStart.Endpoints.ShoppingCarts
{
    public class CreateShoppingCartsResponse : BaseResponse
    {
        public CreateShoppingCartsResponse(Guid correlationId) : base(correlationId)
        {
        }

        public CreateShoppingCartsResponse()
        {
        }
        public int Id { get; set; }
        public ShoppingCartDTO cartItems { get; set; }
    }
}