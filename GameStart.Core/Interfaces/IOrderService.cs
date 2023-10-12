namespace GameStart.Core.Interfaces
{
    public interface IOrderService
    {
        Task CreateOrderAsync(int shoppingCartId, string address);
    }
}
