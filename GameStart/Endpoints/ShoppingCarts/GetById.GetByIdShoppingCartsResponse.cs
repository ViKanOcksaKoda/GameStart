namespace GameStart.Endpoints.ShoppingCarts
{
    public class GetByIdShoppingCartsResponse : BaseResponse
    {

        public GetByIdShoppingCartsResponse(Guid correlationId) : base(correlationId)
        {
        }

        public GetByIdShoppingCartsResponse()
        {
        }
        public ShoppingCartDTO cartItems { get; set; }
        public string ProductName { get; set; }
    }
}
