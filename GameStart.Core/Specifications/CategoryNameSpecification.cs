using Ardalis.Specification;
using GameStart.Core.Entities;

namespace GameStart.Core.Specifications
{
    public class CategoryNameSpecification : Specification<Category>
    {
        public CategoryNameSpecification(string name)
        {
            Query.Where(item => name == item.Name);
        }
    }
}
