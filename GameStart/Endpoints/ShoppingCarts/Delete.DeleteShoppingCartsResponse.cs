namespace GameStart.Endpoints.ShoppingCarts
{
    public class DeleteShoppingCartsResponse : BaseResponse
    {
        public DeleteShoppingCartsResponse(Guid correlationId) : base(correlationId)
        {
        }

        public DeleteShoppingCartsResponse()
        {
        }

        public string Status { get; set; } = "Deleted";
    }
}