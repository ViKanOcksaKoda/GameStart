namespace GameStart.Endpoints.ShoppingCartItems
{
    public class CreateShoppingCartItemResponse : BaseResponse
    {
        public CreateShoppingCartItemResponse(Guid correlationId) : base(correlationId)
        {
        }

        public CreateShoppingCartItemResponse()
        {
        }

        public ShoppingCartItemDTO cartItem { get; set; }
    }
}