using System.ComponentModel.DataAnnotations;

namespace GameStart.Endpoints.Products
{
    public class UpdateProductRequest : BaseRequest
    {
        [Range(1, 10000)]
        public int Id { get; set; }
        [Range(1, 10000)]
        public int CategoryId { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string Name { get; set; }
        [Range(0.01, 10000)]
        public decimal Price { get; set; }
        [Required]
        [Range(0, 10000)]
        public int StockBalance { get; set; }
    }
}
