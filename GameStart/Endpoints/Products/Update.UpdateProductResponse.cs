namespace GameStart.Endpoints.Products
{
    public class UpdateProductResponse : BaseResponse
    {
        public UpdateProductResponse(Guid correlationId) : base(correlationId)
        {
        }

        public UpdateProductResponse()
        {
        }

        public ProductDTO Product { get; set; }
    }
}
