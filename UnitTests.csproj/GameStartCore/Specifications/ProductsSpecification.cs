using GameStart.Core.Entities;
using Moq;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace UnitTests.GameStartCore.Specifications
{
    public class ProductsSpecification
    {
        [Fact]
        public void MatchesSpecificProduct()
        {
            var productIds = new int[] { 1 };
            var spec = new GameStart.Core.Specifications.ProductsSpecification(productIds);

            var result = GetTestCollection()
                .AsQueryable()
                .Where(spec.WhereExpressions.FirstOrDefault());

            Assert.NotNull(result);
            Assert.Single(result.ToList());
        }

        [Fact]
        public void MatchesAllProducts()
        {
            var productIds = new int[] { 1, 3 };
            var spec = new GameStart.Core.Specifications.ProductsSpecification(productIds);

            var result = GetTestCollection()
                .AsQueryable()
                .Where(spec.WhereExpressions.FirstOrDefault());

            Assert.NotNull(result);
            Assert.Equal(2, result.ToList().Count);
        }

        private List<Product> GetTestCollection()
        {
            var products = new List<Product>();

            var mockProduct1 = new Mock<Product>(1, "Product 1 description", "Product 1", 1.5m, 2);
            mockProduct1.SetupGet(x => x.Id).Returns(1);

            var mockProduct3 = new Mock<Product>(3, "Product 3 description", "Product 3", 3.5m, 2);
            mockProduct3.SetupGet(x => x.Id).Returns(3);

            products.Add(mockProduct1.Object);
            products.Add(mockProduct3.Object);

            return products;
        }
    }
}
