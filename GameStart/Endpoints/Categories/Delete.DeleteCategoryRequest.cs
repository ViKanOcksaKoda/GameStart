namespace GameStart.Endpoints.Categories
{
    public class DeleteCategoryRequest : BaseRequest
    {
        //[FromRoute]
        public int CategoryId { get; set; }
    }
}