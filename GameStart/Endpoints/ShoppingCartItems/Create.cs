using Ardalis.ApiEndpoints;
using GameStart.Core.Entities.ShoppingCartAggregate;
using GameStart.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace GameStart.Endpoints.ShoppingCartItems
{
    public class Create : BaseAsyncEndpoint
        .WithRequest<CreateShoppingCartItemRequest>
        .WithResponse<CreateShoppingCartItemResponse>
    {
        private readonly IRepository<ShoppingCartItem> _shoppingCartItemsRepository;
        private readonly IRepository<ShoppingCart> _shoppingCartRepository;

        public Create(IRepository<ShoppingCartItem> shoppingCartItemsRepository, IRepository<ShoppingCart> shoppingCartRepository)
        {
            _shoppingCartItemsRepository = shoppingCartItemsRepository;
            _shoppingCartRepository = shoppingCartRepository;
        }
        [HttpPost("api/shoppingcart/item")]
        [SwaggerOperation(
            Summary = "Creates a new Shoppingcart Item",
            Description = "Creates a new Shoppingcart Item",
            OperationId = "shoppingCartItem.create",
            Tags = new[] { "Shopping Cart Item Endpoints" })
        ]
        public override async Task<ActionResult<CreateShoppingCartItemResponse>> HandleAsync(CreateShoppingCartItemRequest request, CancellationToken cancellationToken)
        {
            var response = new CreateShoppingCartItemResponse(request.CorrelationId());
            var shoppingCartId = 0;
            var item = new ShoppingCartItem(request.ProductId, request.Price, request.Quantity);
            var shoppingCarts = await _shoppingCartRepository.ListAsync(cancellationToken);

            for (int i = 0; i < shoppingCarts.Count; i++)
            {
                if (shoppingCarts[i].UserId == request.UserId.ToString())
                {
                    shoppingCartId = shoppingCarts[i].Id;
                    item.ShoppingCartId = shoppingCartId;
                }
            }
            item = await _shoppingCartItemsRepository.AddAsync(item);
            var dto = new ShoppingCartItemDTO
            {
                Id = item.Id,
                Price = item.UnitPrice,
                ProductId = item.ProductId,
                Quantity = item.Quantity,
                CartId = shoppingCartId,
            };
            response.cartItem = dto;

            return response;
        }
    }
}
