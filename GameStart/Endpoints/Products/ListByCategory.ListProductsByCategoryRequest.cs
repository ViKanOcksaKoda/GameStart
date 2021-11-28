namespace GameStart.Endpoints.Products
{
    public class ListProductsByCategoryRequest : BaseRequest
    {
        public int? CategoryId { get; set; }
    }
}
