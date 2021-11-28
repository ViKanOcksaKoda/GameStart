using GameStart.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace UnitTests.GameStartCore.Specifications
{
    public class CategoryNameSpecification
    {
        [Theory]
        [InlineData(null, 0)]
        [InlineData("Controllers", 1)]
        [InlineData("Games", 1)]
        [InlineData("", 0)]
        [InlineData("Figurines", 0)]
        public void MatchesExpectedNumberOfCategories(string categoryName, int expectedCount)
        {
            var spec = new GameStart.Core.Specifications.CategoryNameSpecification(categoryName);

            var result = GetTestCategoryCollection()
                .AsQueryable()
                .Where(spec.WhereExpressions.FirstOrDefault());

            Assert.Equal(expectedCount, result.Count());
        }

        public List<Category> GetTestCategoryCollection()
        {
            return new List<Category>()
            {
                new Category("Controllers", "Description"),
                new Category("Games", "Description"),
                new Category("Consoles", "Description"),
                new Category("Accessories", "Description"),
            };
        }
    }
}
