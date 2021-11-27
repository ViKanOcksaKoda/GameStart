using GameStart.Core.Entities;
using GameStart.Core.Entities.ShoppingCartAggregate;
using GameStart.Core.Interfaces;
using GameStart.Core.Specifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStart.Core.Services
{
    public class ShoppingCartItemService : IShoppingCartItemService
    {
        private readonly IRepository<Product> _productRepository;

        public ShoppingCartItemService(IRepository<Product> productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<List<ShoppingCartItem>> GetShoppingCartItems(IReadOnlyCollection<ShoppingCartItem> shoppingCartItems)
        {
            var itemsSpecification = new ProductsSpecification(shoppingCartItems.Select(i => i.Id).ToArray());
            var items = await _productRepository.ListAsync(itemsSpecification);

            var products = shoppingCartItems.Select(shoppingCartItems =>
            {
                var item = items.First(i => i.Id == shoppingCartItems.Id);

                var productsItem = new ShoppingCartItem(item.Id, item.Price, item.StockBalance);
                return productsItem;
            }).ToList();

            return products;
        }
    }
}
