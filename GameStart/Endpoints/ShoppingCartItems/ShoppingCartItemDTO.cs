namespace GameStart.Endpoints.ShoppingCartItems
{
    public class ShoppingCartItemDTO
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public int CartId { get; set; }
    }
}
