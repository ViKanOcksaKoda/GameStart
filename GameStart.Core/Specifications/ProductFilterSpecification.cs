using Ardalis.Specification;
using GameStart.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
