using Ardalis.ApiEndpoints;
using Microsoft.AspNetCore.Mvc;

namespace GameStart.Endpoints.ShoppingCarts
{
    public class GetById : BaseAsyncEndpoint
        .WithRequest<GetByIdShoppingCartsRequest>
        .WithResponse<GetByIdShoppingCartsResponse>
    {
        public override Task<ActionResult<GetByIdShoppingCartsResponse>> HandleAsync(GetByIdShoppingCartsRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
