namespace GameStart.Endpoints.Products
{
    public class ListProductsByCategoryResponse : BaseResponse
    {
        public ListProductsByCategoryResponse(Guid correlationId) : base(correlationId)
        {
        }

        public ListProductsByCategoryResponse()
        {
        }

        public List<ProductDTO> Products { get; set; } = new List<ProductDTO>();
    }
}
