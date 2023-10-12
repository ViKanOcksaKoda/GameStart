using GameStart.Core.Entities.ShoppingCartAggregate;
using Xunit;

namespace UnitTests.GameStartCore.Entities.ShoppingCartTests
{

    public class BasketRemoveEmptyItems
    {
        private readonly int _testProductId = 123;
        private readonly decimal _testUnitPrice = 1.23m;
        private readonly string _userId = "Test userId";

        [Fact]
        public void RemovesEmptyBasketItems()
        {
            var basket = new ShoppingCart(_userId);
            basket.AddItem(_testProductId, _testUnitPrice, 0);
            basket.RemoveEmptyItems();

            Assert.Equal(0, basket.Items.Count);
        }
    }
}
