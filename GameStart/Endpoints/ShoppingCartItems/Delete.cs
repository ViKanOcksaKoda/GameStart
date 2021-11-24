using Ardalis.ApiEndpoints;
using Microsoft.AspNetCore.Mvc;

namespace GameStart.Endpoints.ShoppingCartItems
{
    public class Delete : BaseAsyncEndpoint
        .WithRequest<DeleteShoppingCartItemsRequest>
        .WithResponse<DeleteShoppingCartItemsResponse>
    {
        public override Task<ActionResult<DeleteShoppingCartItemsResponse>> HandleAsync(DeleteShoppingCartItemsRequest request, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }
    }
}
