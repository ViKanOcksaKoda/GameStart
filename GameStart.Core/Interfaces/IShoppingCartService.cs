using GameStart.Core.Entities.ShoppingCartAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStart.Core.Interfaces
{
    public interface IShoppingCartService
    {
        Task TransferShoppingCartAsync(string anonymousId, string userName);
        Task<ShoppingCart> AddItemToShoppingCart(string userName, int productId, decimal price, int quantity = 1);
        Task<ShoppingCart> SetQuantities(int shoppingCartId, Dictionary<string, int> quantities);
        Task DeleteShoppingCartAsync(int shoppingCartId);

    }
}
