using GameStart.Core.Entities.ShoppingCartAggregate;
using GameStart.Core.Interfaces;
using GameStart.Core.Services;
using GameStart.Core.Specifications;
using Moq;
using System.Threading.Tasks;
using Xunit;

namespace UnitTests.GameStartCore.Services.ShoppingCartServiceTests
{
    public class AddItemToShoppingCart
    {
        public class AddItemToBasket
        {
            private readonly string _userId = "Test userId";
            private readonly Mock<IRepository<ShoppingCart>> _mockShoppingCartRepo = new();

            [Fact]
            public async Task InvokesShoppingCartRepositoryGetBySpecAsyncOnce()
            {
                var shoppingCart = new ShoppingCart(_userId);
                shoppingCart.AddItem(1, It.IsAny<decimal>(), It.IsAny<int>());
                _mockShoppingCartRepo.Setup(x => x.GetBySpecAsync(It.IsAny<ShoppingCartWithItemsSpecification>(), default)).ReturnsAsync(shoppingCart);

                var shoppingCartService = new ShoppingCartService(_mockShoppingCartRepo.Object, null);

                await shoppingCartService.AddItemToShoppingCart(shoppingCart.UserId, 1, 1.50m);

                _mockShoppingCartRepo.Verify(x => x.GetBySpecAsync(It.IsAny<ShoppingCartWithItemsSpecification>(), default), Times.Once);
            }

            [Fact]
            public async Task InvokesShoppingCartRepositoryUpdateAsyncOnce()
            {
                var shoppingCart = new ShoppingCart(_userId);
                shoppingCart.AddItem(1, It.IsAny<decimal>(), It.IsAny<int>());
                _mockShoppingCartRepo.Setup(x => x.GetBySpecAsync(It.IsAny<ShoppingCartWithItemsSpecification>(), default)).ReturnsAsync(shoppingCart);

                var shoppingCartService = new ShoppingCartService(_mockShoppingCartRepo.Object, null);

                await shoppingCartService.AddItemToShoppingCart(shoppingCart.UserId, 1, 1.50m);

                _mockShoppingCartRepo.Verify(x => x.UpdateAsync(shoppingCart, default), Times.Once);
            }
        }
    }
}
