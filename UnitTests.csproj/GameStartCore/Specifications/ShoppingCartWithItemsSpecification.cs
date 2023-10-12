using GameStart.Core.Entities.ShoppingCartAggregate;
using GameStart.Core.Specifications;
using Moq;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace UnitTests.GameStartCore.Specifications
{
    public class ShoppingCartWithItems
    {
        private readonly int _testShoppingCartId = 123;
        private readonly string _userId = "Test userId";

        [Fact]
        public void MatchesShoppingCartWithGivenShoppingCartId()
        {
            var spec = new ShoppingCartWithItemsSpecification(_testShoppingCartId);

            var result = spec.Evaluate(GetTestShoppingCartCollection()).FirstOrDefault();

            Assert.NotNull(result);
            Assert.Equal(_testShoppingCartId, result.Id);
        }

        [Fact]
        public void MatchesNoShoppingCartsIfShoppingCartIdNotPresent()
        {
            int badShoppingCartId = -1;
            var spec = new ShoppingCartWithItemsSpecification(badShoppingCartId);

            var result = spec.Evaluate(GetTestShoppingCartCollection()).Any();

            Assert.False(result);
        }

        [Fact]
        public void MatchesShoppingCartWithGivenUserId()
        {
            var spec = new ShoppingCartWithItemsSpecification(_userId);

            var result = spec.Evaluate(GetTestShoppingCartCollection()).FirstOrDefault();

            Assert.NotNull(result);
            Assert.Equal(_userId, result.UserId);
        }

        [Fact]
        public void MatchesNoShoppingCartsIfUserIdNotPresent()
        {
            string badUserId = "badUserId";
            var spec = new ShoppingCartWithItemsSpecification(badUserId);

            var result = spec.Evaluate(GetTestShoppingCartCollection()).Any();

            Assert.False(result);
        }

        public List<ShoppingCart> GetTestShoppingCartCollection()
        {
            var basket1Mock = new Mock<ShoppingCart>(_userId);
            basket1Mock.SetupGet(s => s.Id).Returns(1);
            var basket2Mock = new Mock<ShoppingCart>(_userId);
            basket2Mock.SetupGet(s => s.Id).Returns(2);
            var basket3Mock = new Mock<ShoppingCart>(_userId);
            basket3Mock.SetupGet(s => s.Id).Returns(_testShoppingCartId);

            return new List<ShoppingCart>()
            {
                basket1Mock.Object,
                basket2Mock.Object,
                basket3Mock.Object
            };
        }
    }
}
