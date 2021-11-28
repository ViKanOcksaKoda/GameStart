using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStart.Core.Interfaces
{
    public interface IShoppingCartQueryService
    {
        Task<int> CountTotalBasketItems(string userName);
    }
}
