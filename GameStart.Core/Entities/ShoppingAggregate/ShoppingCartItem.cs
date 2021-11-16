using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStart.Core.Entities.ShoppingAggregate
{
    public class ShoppingCartItem : BaseEntity
    {
        public Product Product { get; set; }
        public double TotalPrice { get; set; }
        public int Quantity { get; set; }
    }
}
