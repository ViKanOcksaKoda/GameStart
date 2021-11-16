using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStart.Core.Entities
{
    public class Order : BaseEntity
    {
        public int UserId { get; set; }
        public DateTimeOffset date { get; set; }
        public string Address { get; set; }
    }
}
