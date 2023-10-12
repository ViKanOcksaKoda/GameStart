using Ardalis.Specification;
using GameStart.Core.Entities;

namespace GameStart.Core.Specifications
{
    public class ProductsSpecification : Specification<Product>
    {
        public ProductsSpecification(params int[] ids)
        {
            Query.Where(p => ids.Contains(p.Id));
        }
    }
}
