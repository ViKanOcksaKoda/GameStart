using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStart.Core.Exceptions
{
    public class ShoppingCartNotFoundException : Exception
    {
        public ShoppingCartNotFoundException(int basketId) : base($"No basket found with id {basketId}")
        {
        }
    }
}
