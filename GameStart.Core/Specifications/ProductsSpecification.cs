using Ardalis.Specification;
using GameStart.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
