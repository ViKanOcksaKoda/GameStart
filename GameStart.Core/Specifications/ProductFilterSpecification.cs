using Ardalis.Specification;
using GameStart.Core.Entities;

namespace GameStart.Core.Specifications
{
    public class ProductFilterSpecification : Specification<Product>
    {
        public ProductFilterSpecification(int? categoryId)
        {
            Query.Where(i => !categoryId.HasValue || i.CategoryId == categoryId);
        }
    }
}
