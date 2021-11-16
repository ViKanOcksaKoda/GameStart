using GameStart.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStart.Core.Entities
{
    public class Product : BaseEntity, IAggregateRoot
    {
        public int CategoryId { get; private set; }
        public string ProductName { get; private set; }
        public string Description { get; private set; }
        public decimal Price { get; private set; }
        public int StockBalance { get; private set; }

        public Product(int categoryId,
            string productName,
            string description,
            decimal price,
            int stockBalance)
        {
            CategoryId = categoryId;
            ProductName = productName;
            Description = description;
            Price = price;
            StockBalance = stockBalance;
        }
    }
}
