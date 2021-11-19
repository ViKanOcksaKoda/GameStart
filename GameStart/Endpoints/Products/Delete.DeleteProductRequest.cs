namespace GameStart.Endpoints.Products
{
    public class DeleteProductRequest : BaseRequest
    {
        //[FromRoute]
        public int ProductId { get; set; }
    }
}
