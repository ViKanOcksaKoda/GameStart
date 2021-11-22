namespace GameStart.Endpoints.Categories
{
    public class DeleteCategoryResponse : BaseResponse
    {
        public DeleteCategoryResponse(Guid correlationId) : base(correlationId)
        {
        }

        public DeleteCategoryResponse()
        {
        }

        public string Status { get; set; } = "Deleted";
    }
}