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
        public string Name { get; private set; }
        public string Description { get; private set; }

        public Category(string name, string description)
        {
            Name = name;
            Description = description;
        }
        
        public void UpdateCategory(string name, string description)
        {
            Name = name;
            Description = description;
        }
    }
}
