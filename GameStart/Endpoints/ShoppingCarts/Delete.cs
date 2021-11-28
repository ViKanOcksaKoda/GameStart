using Ardalis.ApiEndpoints;
using GameStart.Core.Entities.ShoppingCartAggregate;
using GameStart.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace GameStart.Endpoints.ShoppingCarts
{
    public class Delete : BaseAsyncEndpoint
        .WithRequest<DeleteShoppingCartsRequest>
        .WithResponse<DeleteShoppingCartsResponse>
    {
        private readonly IRepository<ShoppingCart> _shoppingCartRepository;
        private readonly IRepository<ShoppingCartItem> _shoppingCartItemRepository;
        public Delete(IRepository<ShoppingCart> shoppingCartRepository, IRepository<ShoppingCartItem> shoppingCartItemRepository)
        {
            _shoppingCartRepository = shoppingCartRepository;
            _shoppingCartItemRepository = shoppingCartItemRepository;
        }
        [HttpDelete("api/shoppingcarts/{UserId}")]
        [SwaggerOperation(
           Summary = "Empty a Shopping Cart by UserId",
           Description = "Deletes all Shopping Cart Items by UserId",
           OperationId = "shoppingCart.Delete",
           Tags = new[] { "Shopping Cart Endpoints" })
        ]
        public override async Task<ActionResult<DeleteShoppingCartsResponse>> HandleAsync([FromRoute]DeleteShoppingCartsRequest request, CancellationToken cancellationToken)
        {
            var response = new DeleteShoppingCartsResponse(request.CorrelationId());
            var items = await _shoppingCartItemRepository.ListAsync(cancellationToken);
            var carts = await _shoppingCartRepository.ListAsync(cancellationToken);
            int userCart = 0;
            
            for(int i = 0; i < carts.Count; i++)
            {
                if(carts[i].UserId == request.UserId)
                {
                    userCart = carts[i].Id;
                    for(int u = 0; u < items.Count; u++)
                    {
                        if(items[u].ShoppingCartId == userCart)
                        {
                            await _shoppingCartItemRepository.DeleteAsync(items[u]);
                        }
                    }
                }
            }
            
            return Ok(response);
        }
    }
}
