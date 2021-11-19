namespace GameStart.Endpoints.Categories
{
    public class CreateCategoryResponse : BaseResponse
    {
        public CreateCategoryResponse(Guid correlationId) : base(correlationId)
        {
        }

        public CreateCategoryResponse()
        {
        }

        public CategoryDTO Category { get; set; }
    }
}
