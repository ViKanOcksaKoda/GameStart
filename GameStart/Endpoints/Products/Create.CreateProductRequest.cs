namespace GameStart.Endpoints.Products
{
    public class CreateProductRequest : BaseRequest
    {
        public string Description { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int StockBalance { get; set; }
        public int CategoryId { get; set; }
    }
}
