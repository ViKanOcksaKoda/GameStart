using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStart.Core.Entities
{
    public class Product : BaseEntity
    {
        public int CategoryId { get; set; }
        public string ProductName { get; set; }
        public string Description { get; set; }
        public decimal UnitPrice { get; set; }
        public int StockBalance { get; set; }

        public Product(int categoryId,
            string productName,
            string description,
            decimal unitPrice,
            int stockBalance)
        {
            CategoryId = categoryId;
            ProductName = productName;
            Description = description;
            UnitPrice = unitPrice;
            StockBalance = stockBalance;
        }
    }
}
