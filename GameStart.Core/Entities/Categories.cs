using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStart.Core.Entities
{
    public class Categories : BaseEntity
    {
        public string CategoryName { get; set; }
        public string CategoryDescription { get; set; }
        
        public List<Product> Products { get; set; }
    }
}
