using GameStart.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStart.Core.Entities
{
    public class Category : BaseEntity, IAggregateRoot
    {
        public string CategoryName { get; private set; }
        public string CategoryDescription { get; private set; }

        public Category(string categoryName, string categoryDescription)
        {
            CategoryName = categoryName;
            CategoryDescription = categoryDescription;
        }
    }
}
