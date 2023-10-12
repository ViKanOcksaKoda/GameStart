using GameStart.Core.Entities.ShoppingCartAggregate;
using GameStart.Core.Interfaces;
using GameStart.Core.Services;
using Moq;
using System.Threading.Tasks;
using Xunit;

namespace UnitTests.GameStartCore.Services.ShoppingCartServiceTests
{
    public class DeleteShoppingCart
    {
        private readonly string _userId = "Test userId";
        private readonly Mock<IRepository<ShoppingCart>> _mockShoppingCartRepo = new();

        [Fact]
        public async Task ShouldInvokeBasketRepositoryDeleteAsyncOnce()
        {
            var shoppingCart = new ShoppingCart(_userId);
            shoppingCart.AddItem(1, It.IsAny<decimal>(), It.IsAny<int>());
            shoppingCart.AddItem(2, It.IsAny<decimal>(), It.IsAny<int>());
            _mockShoppingCartRepo.Setup(x => x.GetByIdAsync(It.IsAny<int>(), default))
                .ReturnsAsync(shoppingCart);
            var shoppingCartService = new ShoppingCartService(_mockShoppingCartRepo.Object, null);

            await shoppingCartService.DeleteShoppingCartAsync(It.IsAny<int>());

            _mockShoppingCartRepo.Verify(x => x.DeleteAsync(It.IsAny<ShoppingCart>(), default), Times.Once);
        }
    }
}
