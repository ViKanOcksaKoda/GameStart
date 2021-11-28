using Ardalis.ApiEndpoints;
using GameStart.Core.Entities;
using GameStart.Core.Entities.OrderAggregate;
using GameStart.Core.Entities.ShoppingCartAggregate;
using GameStart.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace GameStart.Endpoints.Orders
{
    public class Create : BaseAsyncEndpoint
        .WithRequest<CreateOrdersRequest>
        .WithResponse<CreateOrdersResponse>
    {
        private readonly IRepository<Order> _orderRepository;
        private readonly IRepository<OrderItem> _orderItemRepository;
        private readonly IRepository<Product> _productRepository;

        public Create(IRepository<Order> orderRepository, IRepository<OrderItem> orderItemRepository, IRepository<Product> productRepository)
        {
            _orderRepository = orderRepository;
            _orderItemRepository = orderItemRepository;
            _productRepository = productRepository;
        }
        [HttpPost("api/order")]
        [SwaggerOperation(
            Summary = "Create order",
            Description = "Create order from Shoppingcart Items",
            OperationId = "order.Create",
            Tags = new[] {"Order Endpoints"})
        ]
        public override async Task<ActionResult<CreateOrdersResponse>> HandleAsync(CreateOrdersRequest request, CancellationToken cancellationToken = default)
        {
            var response = new CreateOrdersResponse(request.CorrelationId());
            var orderItem = new List<OrderItem>();
            var allProducts = await _productRepository.ListAsync(cancellationToken);
            int prodQuantity = 0;

            foreach(var item in request.cartItem)
            {
                var eachItem = new OrderItem(item.UnitPrice, item.Quantity);
                orderItem.Add(eachItem);
                prodQuantity = item.Quantity;
                var specificProduct = allProducts.Find(x => x.Id.Equals(item.ProductId));
                specificProduct.StockBalance = specificProduct.StockBalance - prodQuantity;

                await _productRepository.UpdateAsync(specificProduct);
            }

            var order = new Order(request.UserId, request.Adress, orderItem);
            order = await _orderRepository.AddAsync(order);

            foreach (var item in orderItem)
            {
                var prod = new OrderItem(item.UnitPrice, item.Units);
            }
            
            var dto = new OrderDTO
            {
                Id = order.Id,
                UserId = order.UserId,
                Address = order.Address,
                OrderItem = orderItem
            };
            response.order = dto;
            return response;
        }
    }
}
