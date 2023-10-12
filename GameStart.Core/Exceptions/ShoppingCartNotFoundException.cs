namespace GameStart.Core.Exceptions
{
    public class ShoppingCartNotFoundException : Exception
    {
        public ShoppingCartNotFoundException(int basketId) : base($"No basket found with id {basketId}")
        {
        }
    }
}
