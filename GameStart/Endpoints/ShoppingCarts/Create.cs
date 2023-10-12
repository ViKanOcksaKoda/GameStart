using Ardalis.ApiEndpoints;
using GameStart.Core.Entities.ShoppingCartAggregate;
using GameStart.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

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

            await _shoppingCartRepository.AddAsync(newCart, cancellationToken);

            var dto = new ShoppingCartDTO
            {
                ShoppingCartItem = request.ShoppingCartItem,
                UserId = request.UserId,
            };
            response.cartItems = dto;

            return response;
        }
    }
}
