using GameStart.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace UnitTests.GameStartCore.Entities.ProductTests
{
    public class UpdateCategory
    {
        private Product _testItem;
        private int _validCategoryId = 1;
        private string _validDescription = "test description";
        private string _validName = "test name";
        private decimal _validPrice = 1.23m;
        private int _validStockBalance = 10;

        public UpdateCategory()
        {
            _testItem = new Product(_validCategoryId, _validDescription, _validName, _validPrice, _validStockBalance);
        }

        [Fact]
        public void ThrowsArgumentExceptionGivenEmptyName()
        {
            int newValue = -11;
            Assert.Throws<ArgumentException>(() => _testItem.UpdateCategory(newValue));
        }
    }
}
