namespace GameStart.Endpoints.Products
{
    public class DeleteProductResponse : BaseResponse
    {
        public DeleteProductResponse(Guid correlationId) : base(correlationId)
        {
        }

        public DeleteProductResponse()
        {
        }

        public string Status { get; set; } = "Deleted";
    }
}
