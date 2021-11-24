using Ardalis.ApiEndpoints;
using Microsoft.AspNetCore.Mvc;

namespace GameStart.Endpoints.ShoppingCarts
{
    public class Delete : BaseAsyncEndpoint
        .WithRequest<DeleteShoppingCartsRequest>
        .WithResponse<DeleteShoppingCartsResponse>
    {
        public override Task<ActionResult<DeleteShoppingCartsResponse>> HandleAsync(DeleteShoppingCartsRequest request, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }
    }
}
