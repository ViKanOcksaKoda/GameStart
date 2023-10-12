using Ardalis.ApiEndpoints;
using AutoMapper;
using GameStart.Core.Entities;
using GameStart.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace GameStart.Endpoints.Orders
{
    public class List : BaseAsyncEndpoint
        .WithoutRequest
        .WithResponse<ListOrderResponse>
    {
        private readonly IRepository<Order> _orderRepository;
        private readonly IMapper _mapper;

        public List(IRepository<Order> orderRepository, IMapper mapper)
        {
            _orderRepository = orderRepository;
            _mapper = mapper;
        }
        [HttpGet("api/orders/list")]
        [SwaggerOperation(
            Summary = "Get a list of all order",
            Description = "Gets a list of all orders made",
            OperationId = "order.List",
            Tags = new[] { "Order Endpoints" })
        ]
        public override async Task<ActionResult<ListOrderResponse>> HandleAsync(CancellationToken cancellationToken = default)
        {
            var response = new ListOrderResponse();
            var orders = await _orderRepository.ListAsync(cancellationToken);

            response.Orders.AddRange(orders.Select(_mapper.Map<OrderDTO>));

            return Ok(response);
        }
    }
}
