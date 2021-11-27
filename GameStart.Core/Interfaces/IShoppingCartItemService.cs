using GameStart.Core.Entities;
using GameStart.Core.Entities.ShoppingCartAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStart.Core.Interfaces
{
    public interface IShoppingCartItemService
    {
        Task<List<ShoppingCartItem>> GetShoppingCartItems(IReadOnlyCollection<ShoppingCartItem> shoppingCartItems);
    }
}
