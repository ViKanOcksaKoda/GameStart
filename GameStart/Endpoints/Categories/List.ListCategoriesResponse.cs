namespace GameStart.Endpoints.Categories
{
    public class ListCategoriesResponse : BaseResponse
    {
        public ListCategoriesResponse(Guid correlationId) : base(correlationId)
        {
        }

        public ListCategoriesResponse()
        {
        }

        public List<CategoryDTO> Categories { get; set; } = new List<CategoryDTO>();
    }
}
