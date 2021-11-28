using System.ComponentModel.DataAnnotations;

namespace GameStart.Endpoints.Categories
{
    public class UpdateCategoryRequest : BaseRequest
    {
        [Range (1, 10000)]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
    }
}