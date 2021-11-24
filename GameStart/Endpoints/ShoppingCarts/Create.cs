using Ardalis.ApiEndpoints;
using Microsoft.AspNetCore.Mvc;

namespace GameStart.Endpoints.ShoppingCarts
{
    public class Create : BaseAsyncEndpoint
        .WithRequest<CreateShoppingCartsRequest>
        .WithResponse<CreateShoppingCartsResponse>
    {
        public override Task<ActionResult<CreateShoppingCartsResponse>> HandleAsync(CreateShoppingCartsRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
