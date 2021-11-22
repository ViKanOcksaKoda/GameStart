namespace GameStart.Endpoints.Categories
{
    public class UpdateCategoryResponse : BaseResponse
    {
        public UpdateCategoryResponse(Guid correlationId) : base(correlationId)
        {
        }

        public UpdateCategoryResponse()
        {
        }

        public CategoryDTO Category { get; set; }
    }
}