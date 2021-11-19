using Ardalis.Specification;
using GameStart.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
