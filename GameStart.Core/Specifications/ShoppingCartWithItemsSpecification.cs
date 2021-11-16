using Ardalis.Specification;
using GameStart.Core.Entities.ShoppingCartAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStart.Core.Specifications
{
    public sealed class ShoppingCartWithItemsSpecification : Specification<ShoppingCart>, ISingleResultSpecification
    {
        public ShoppingCartWithItemsSpecification(int shoppingCartId)
        {
            Query
                .Where(sc => sc.Id == shoppingCartId)
                .Include(sc => sc.Items);
        }

        public ShoppingCartWithItemsSpecification(string userId)
        {
            Query
                .Where(sc => sc.UserId == userId)
                .Include(sc => sc.Items);
        }
    }
}
