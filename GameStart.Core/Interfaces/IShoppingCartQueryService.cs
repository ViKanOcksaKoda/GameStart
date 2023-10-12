namespace GameStart.Core.Interfaces
{
    public interface IShoppingCartQueryService
    {
        Task<int> CountTotalBasketItems(string userName);
    }
}
