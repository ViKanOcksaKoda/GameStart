namespace GameStart.Endpoints.Categories
{
    public class CreateCategoryRequest : BaseRequest
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
