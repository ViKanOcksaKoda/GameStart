using Ardalis.Specification;
using GameStart.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
