using GameStart.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace UnitTests.GameStartCore.Specifications
{
    public class UserNameSpecification
    {
        [Theory]
        [InlineData(null, 0)]
        [InlineData("DonOllario", 1)]
        [InlineData("Vivzan", 1)]
        [InlineData("", 0)]
        [InlineData("Mackan", 0)]
        public void MatchesExpectedNumberOfUsers(string userName, int expectedCount)
        {
            var spec = new GameStart.Core.Specifications.UserNameSpecification(userName);

            var result = GetTestCategoryCollection()
                .AsQueryable()
                .Where(spec.WhereExpressions.FirstOrDefault());

            Assert.Equal(expectedCount, result.Count());
        }

        public List<User> GetTestCategoryCollection()
        {
            return new List<User>()
            {
                new User("DonOllario", "123", "guest", "James", "Smith"),
                new User("Vivzan", "123", "guest", "James", "Smith"),
                new User("Krilleboi", "123", "guest", "James", "Smith"),
                new User("dani-dvp", "123", "guest", "James", "Smith"),
                new User("RickyMartin_94", "123", "guest", "James", "Smith"),
            };
        }
    }
}
