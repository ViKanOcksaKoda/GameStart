using GameStart.Core.Services;
using System;
using System.Threading.Tasks;
using Xunit;

namespace UnitTests.GameStartCore.Services.ShoppingCartServiceTests
{
    public class SetQuantities
    {
        //private readonly int _invalidId = -1;
        //private readonly Mock<IRepository<ShoppingCart>> _mockShoppingCartRepo = new();

        //[Fact]
        //public async Task ThrowsGivenInvalidBasketId()
        //{
        //    var shoppingCartService = new ShoppingCartService(_mockShoppingCartRepo.Object, null);

        //    await Assert.ThrowsAsync<ShoppingCartNotFoundException>(async () =>
        //        await shoppingCartService.SetQuantities(_invalidId, new System.Collections.Generic.Dictionary<string, int>()));
        //}

        [Fact]
        public async Task ThrowsGivenNullQuantities()
        {
            var basketService = new ShoppingCartService(null, null);

            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
                await basketService.SetQuantities(123, null));
        }
    }
}
