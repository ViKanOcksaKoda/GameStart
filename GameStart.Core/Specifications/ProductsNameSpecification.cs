using Ardalis.Specification;
using GameStart.Core.Entities;

namespace GameStart.Core.Specifications
{
    public class ProductNameSpecification : Specification<Product>
    {
        public ProductNameSpecification(string productName)
        {
            Query.Where(item => productName == item.Name);
        }
    }
}
