namespace GameStart.Endpoints.ShoppingCartItems
{
    public class CreateShoppingCartItemRequest : BaseRequest
    {
        public int UserId { get; set; }
        public int ProductId { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
    }
}