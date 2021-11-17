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
    public class ShoppingCartService : IShoppingCartService
    {
        private readonly IRepository<ShoppingCart> _shoppingCartRepository;
        private readonly IAppLogger<ShoppingCartService> _logger;

        public ShoppingCartService(IRepository<ShoppingCart> shoppingCartRepository,
            IAppLogger<ShoppingCartService> logger)
        {
            _shoppingCartRepository = shoppingCartRepository;
            _logger = logger;
        }

        public async Task<ShoppingCart> AddItemToShoppingCart(string userName, int productId, decimal price, int quantity = 1)
        {
            var shoppingCartSpec = new ShoppingCartWithItemsSpecification(userName);
            var shoppingCart = await _shoppingCartRepository.GetBySpecAsync(shoppingCartSpec);

            if (shoppingCart == null)
            {
                shoppingCart = new ShoppingCart(userName);
                await _shoppingCartRepository.AddAsync(shoppingCart);
            }

            shoppingCart.AddItem(productId, price, quantity);

            await _shoppingCartRepository.UpdateAsync(shoppingCart);
            return shoppingCart;
        }


        public async Task DeleteShoppingCartAsync(int shoppingCartId)
        {
            var shoppingCart = await _shoppingCartRepository.GetByIdAsync(shoppingCartId);
            await _shoppingCartRepository.DeleteAsync(shoppingCart);
        }

        public async Task<ShoppingCart> SetQuantities(int shoppingCartId, Dictionary<string, int> quantities)
        {
            var shoppingCartSpec = new ShoppingCartWithItemsSpecification(shoppingCartId);
            var shoppingCart = await _shoppingCartRepository.GetBySpecAsync(shoppingCartSpec);

            foreach (var item in shoppingCart.Items)
            {
                if (quantities.TryGetValue(item.Id.ToString(), out var quantity))
                {
                    if (_logger != null) _logger.LogInformation($"Updating quantity of item ID:{item.Id} to {quantity}.");
                    item.SetQuantity(quantity);
                }
            }
            shoppingCart.RemoveEmptyItems();
            await _shoppingCartRepository.UpdateAsync(shoppingCart);
            return shoppingCart;
        }


        public async Task TransferShoppingCartAsync(string anonymousId, string userName)
        {
            var anonymousShoppingCartSpec = new ShoppingCartWithItemsSpecification(anonymousId);
            var anonymousShoppingCart = await _shoppingCartRepository.GetBySpecAsync(anonymousShoppingCartSpec);
            if (anonymousShoppingCart == null) return;
            var userShoppingCartSpec = new ShoppingCartWithItemsSpecification(userName);
            var userShoppingCart = await _shoppingCartRepository.GetBySpecAsync(userShoppingCartSpec);
            if (userShoppingCart == null)
            {
                userShoppingCart = new ShoppingCart(userName);
                await _shoppingCartRepository.AddAsync(userShoppingCart);
            }
            foreach (var item in anonymousShoppingCart.Items)
            {
                userShoppingCart.AddItem(item.ProductId, item.UnitPrice, item.Quantity);
            }
            await _shoppingCartRepository.UpdateAsync(userShoppingCart);
            await _shoppingCartRepository.DeleteAsync(anonymousShoppingCart);
        }
    }
}
