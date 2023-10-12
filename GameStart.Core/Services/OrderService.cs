using GameStart.Core.Entities;
using GameStart.Core.Entities.OrderAggregate;
using GameStart.Core.Entities.ShoppingCartAggregate;
using GameStart.Core.Interfaces;
using GameStart.Core.Specifications;

namespace GameStart.Core.Services
{
    public class OrderService : IOrderService
    {
        private readonly IRepository<Order> _orderRepository;
        private readonly IRepository<ShoppingCart> _shoppingCartRepository;
        private readonly IRepository<Product> _productRepository;

        public OrderService(IRepository<Order> orderRepository,
            IRepository<ShoppingCart> shoppingCartRepository,
            IRepository<Product> productRepository)
        {
            _orderRepository = orderRepository;
            _shoppingCartRepository = shoppingCartRepository;
            _productRepository = productRepository;
        }

        public async Task CreateOrderAsync(int shoppingCartId, string address)
        {
            var shoppingCartSpec = new ShoppingCartWithItemsSpecification(shoppingCartId);
            var shoppingCart = await _shoppingCartRepository.GetBySpecAsync(shoppingCartSpec);

            var productsSpecification = new ProductsSpecification(shoppingCart.Items.Select(item => item.ProductId).ToArray());
            var products = await _productRepository.ListAsync(productsSpecification);

            var items = shoppingCart.Items.Select(shoppingCartItem =>
            {
                var product = products.First(p => p.Id == shoppingCartItem.ProductId);
                var orderItem = new OrderItem(shoppingCartItem.UnitPrice, shoppingCartItem.Quantity);
                return orderItem;
            }).ToList();

            var order = new Order(shoppingCart.UserId, address, items);

            await _orderRepository.AddAsync(order);
        }
    }
}
