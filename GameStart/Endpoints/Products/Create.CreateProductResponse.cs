namespace GameStart.Endpoints.Products
{
    public class CreateProductResponse : BaseResponse
    {
        public CreateProductResponse(Guid correlationId) : base(correlationId)
        {
        }

        public CreateProductResponse()
        {
        }

        public ProductDTO Product { get; set; }
    }
}
