namespace GameStart.Endpoints.Categories
{
    public class GetByIdCategoryResponse : BaseResponse
    {
        public GetByIdCategoryResponse(Guid correlationId) : base(correlationId)
        {
        }

        public GetByIdCategoryResponse()
        {
        }

        public CategoryDTO Category { get; set; }
    }
}