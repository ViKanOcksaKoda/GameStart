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
        
        public string Name { get; private set; }
        public string Description { get; private set; }
        public decimal Price { get; private set; }
        public int StockBalance { get; private set; }
        public int CategoryId { get; private set; }
        public Category Category { get; private set; }

        public Product(int categoryId,
            string name,
            string description,
            decimal price,
            int stockBalance)
        {
            CategoryId = categoryId;
            Name = name;
            Description = description;
            Price = price;
            StockBalance = stockBalance;
        }
    }
}
