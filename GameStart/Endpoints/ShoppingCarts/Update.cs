using Ardalis.ApiEndpoints;
using Microsoft.AspNetCore.Mvc;

namespace GameStart.Endpoints.ShoppingCarts
{
    public class Update : BaseAsyncEndpoint
        .WithRequest<UpdateShoppingCartsRequest>
        .WithResponse<UpdateShoppingCartsResponse>
    {
        public override Task<ActionResult<UpdateShoppingCartsResponse>> HandleAsync(UpdateShoppingCartsRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
