using GameStart.Core.Entities;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace UnitTests.GameStartCore.Specifications
{
    public class ProductsNameSpecification
    {
        [Theory]
        [InlineData(null, 0)]
        [InlineData("Valheim", 1)]
        [InlineData("New World", 1)]
        [InlineData("", 0)]
        [InlineData("Call of Duty", 0)]
        public void MatchesExpectedNumberOfProducts(string productName, int expectedCount)
        {
            var spec = new GameStart.Core.Specifications.ProductNameSpecification(productName);

            var result = GetTestItemCollection()
                .AsQueryable()
                .Where(spec.WhereExpressions.FirstOrDefault());

            Assert.Equal(expectedCount, result.Count());
        }

        public List<Product> GetTestItemCollection()
        {
            return new List<Product>()
            {
                new Product(1, "Valheim", "Description", 0, 0),
                new Product(2, "New World", "Description", 0, 0),
                new Product(2, "Zelda", "Description", 0, 0),
                new Product(3, "WoW", "Description", 0, 0),
            };
        }
    }
}
