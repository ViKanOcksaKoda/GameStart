using GameStart.Core.Entities.ShoppingCartAggregate;

namespace GameStart.Core.Interfaces
{
    public interface IShoppingCartItemService
    {
        Task<List<ShoppingCartItem>> GetShoppingCartItems(IReadOnlyCollection<ShoppingCartItem> shoppingCartItems);
    }
}
