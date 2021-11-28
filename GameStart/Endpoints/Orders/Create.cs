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

        public Create(IRepository<Order> orderRepository, IRepository<OrderItem> orderItemRepository)
        {
            _orderRepository = orderRepository;
            _orderItemRepository = orderItemRepository;
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
            foreach(var item in request.cartItem)
            {
                var eachItem = new OrderItem(item.UnitPrice, item.Quantity);
                orderItem.Add(eachItem);
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
