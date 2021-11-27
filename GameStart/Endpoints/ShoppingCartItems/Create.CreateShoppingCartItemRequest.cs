namespace GameStart.Endpoints.ShoppingCartItems
{
    public class CreateShoppingCartItemRequest : BaseRequest
    {
        public int ProductId { get; set; }
        public int CartId { get; set; }
    }
}