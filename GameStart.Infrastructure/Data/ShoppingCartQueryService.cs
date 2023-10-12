using GameStart.Core.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace GameStart.Infrastructure.Data
{
    public class ShoppingCartQueryService : IShoppingCartQueryService
    {
        private readonly GameStartContext _dbContext;

        public ShoppingCartQueryService(GameStartContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<int> CountTotalBasketItems(string username)
        {
            var totalItems = await _dbContext.ShoppingCarts
                .Where(ShoppingCart => ShoppingCart.UserId == username)
                .SelectMany(item => item.Items)
                .SumAsync(sum => sum.Quantity);

            return totalItems;
        }
    }
}
