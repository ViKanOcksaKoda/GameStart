using Ardalis.ApiEndpoints;
using GameStart.Core.Entities;
using GameStart.Core.Entities.ShoppingCartAggregate;
using GameStart.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace GameStart.Endpoints.ShoppingCarts
{
    public class GetById : BaseAsyncEndpoint
        .WithRequest<GetByIdShoppingCartsRequest>
        .WithResponse<GetByIdShoppingCartsResponse>
    {
        private readonly IRepository<ShoppingCart> _shoppingCartRepository;

        public GetById(IRepository<ShoppingCart> shoppingCartRepository)
        {
            _shoppingCartRepository = shoppingCartRepository;
        }
        [HttpGet("api/shoppingcart/{UserId}/{ShoppingCartId}")]
        [SwaggerOperation(
            Summary = "Get a Shopping Cart by Id",
            Description = "Gets a Shopping Cart by Id",
            OperationId = "shoppingCart.GetById",
            Tags = new[] { "Shopping Cart Endpoints" })
        ]
        public override async Task<ActionResult<GetByIdShoppingCartsResponse>> HandleAsync([FromRoute] GetByIdShoppingCartsRequest request, CancellationToken cancellationToken)
        {
            var response = new GetByIdShoppingCartsResponse(request.CorrelationId());

            var cart = await _shoppingCartRepository.GetByIdAsync(request.ShoppingCartId);

            if (cart == null) return NotFound();

            response.cartItems = new ShoppingCartDTO
            {
                UserId = request.UserId
            };

            return response;
        }
    }
}
