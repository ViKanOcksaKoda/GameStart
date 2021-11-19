namespace GameStart.Endpoints.Products
{
    public class GetByIdProductResponse : BaseResponse
    {
        public GetByIdProductResponse(Guid correlationId) : base(correlationId)
        {
        }

        public GetByIdProductResponse()
        {
        }

        public ProductDTO Product { get; set; }
    }
}
