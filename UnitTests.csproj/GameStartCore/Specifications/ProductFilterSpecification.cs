using GameStart.Core.Entities;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace UnitTests.GameStartCore.Specifications
{
    public class ProductFilterSpecification
    {
        [Theory]
        [InlineData(null, 6)]
        [InlineData(1, 1)]
        [InlineData(2, 2)]
        [InlineData(3, 3)]
        [InlineData(5, 0)]
        public void MatchesExpectedNumberOfItems(int? categoryId, int expectedCount)
        {
            var spec = new GameStart.Core.Specifications.ProductFilterSpecification(categoryId);

            var result = GetTestItemCollection()
                .AsQueryable()
                .Where(spec.WhereExpressions.FirstOrDefault());

            Assert.Equal(expectedCount, result.Count());
        }

        public List<Product> GetTestItemCollection()
        {
            return new List<Product>()
            {
                new Product(1, "Description", "Name", 0, 0),
                new Product(2, "Description", "Name", 0, 0),
                new Product(2, "Description", "Name", 0, 0),
                new Product(3, "Description", "Name", 0, 0),
                new Product(3, "Description", "Name", 0, 0),
                new Product(3, "Description", "Name", 0, 0),
            };
        }
    }
}
