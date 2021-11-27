using Ardalis.ApiEndpoints;
using GameStart.Core.Entities;
using GameStart.Core.Entities.ShoppingCartAggregate;
using GameStart.Core.Interfaces;
using GameStart.Core.Specifications;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Collections.Generic;

namespace GameStart.Endpoints.ShoppingCarts
{
    public class Create : BaseAsyncEndpoint
        .WithRequest<CreateShoppingCartsRequest>
        .WithResponse<CreateShoppingCartsResponse>
    {
        private readonly IRepository<ShoppingCart> _shoppingCartRepository;
        public Create(IRepository<ShoppingCart> shoppingCartRepository)
        {
            _shoppingCartRepository = shoppingCartRepository;
        }
        [HttpPost("api/shoppingcarts")]
        [SwaggerOperation(
            Summary = "Creates a new Shopping Cart",
            Description = "Creates a new Shopping Cart",
            OperationId = "shoppingCart.create",
            Tags = new[] { "Shopping Cart Endpoints" })
        ]
        public override async Task<ActionResult<CreateShoppingCartsResponse>> HandleAsync(CreateShoppingCartsRequest request, CancellationToken cancellationToken)
        {
            var response = new CreateShoppingCartsResponse(request.CorrelationId());
            var newCart = new ShoppingCart(request.UserId.ToString());

            newCart = await _shoppingCartRepository.AddAsync(newCart, cancellationToken);

            var dto = new ShoppingCartDTO
            {
                shoppingCartItem = request.ShoppingCartItem,
                UserId = request.UserId,
            };
            response.cartItems = dto;

            return response;
        }
    }
}
