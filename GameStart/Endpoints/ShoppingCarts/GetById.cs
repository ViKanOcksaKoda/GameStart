using Ardalis.ApiEndpoints;
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
        [HttpGet("api/shoppingcart/{UserId}")]
        [SwaggerOperation(
            Summary = "Get a Shopping Cart by Id",
            Description = "Gets a Shopping Cart by Id",
            OperationId = "shoppingCart.GetById",
            Tags = new[] { "Shopping Cart Endpoints" })
        ]
        public override async Task<ActionResult<GetByIdShoppingCartsResponse>> HandleAsync([FromRoute] GetByIdShoppingCartsRequest request, CancellationToken cancellationToken)
        {
            var response = new GetByIdShoppingCartsResponse(request.CorrelationId());


            var allCarts = await _shoppingCartRepository.ListAsync(cancellationToken);

            for(int i = 0; i < allCarts.Count; i++)
            {
                if(allCarts[i].UserId == request.UserId)
                {
                    response.cartItems = new ShoppingCartDTO
                    {
                        UserId = allCarts[i].UserId,
                        ShoppingCartId = allCarts[i].Id
                    };
                }
            }

            if (response.cartItems == null) return NotFound();

            

            return response;
        }
    }
}
