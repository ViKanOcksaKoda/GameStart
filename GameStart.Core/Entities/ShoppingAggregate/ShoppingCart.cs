using GameStart.Core.Entities.ShoppingAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStart.Core.Entities
{
    public class ShoppingCart : BaseEntity
    {
        public int UserId { get; set; }
        private readonly List<ShoppingCartItem> _shoppingCartItems = new List<ShoppingCartItem>();
    }
}
