using Ardalis.ApiEndpoints;
using Microsoft.AspNetCore.Mvc;

namespace GameStart.Endpoints.ShoppingCartItems
{
    public class GetById : BaseAsyncEndpoint
        .WithRequest<GetByIdShoppingCartItemsRequest>
        .WithResponse<GetByIdShoppingCartItemsResponse>
    {
        public override Task<ActionResult<GetByIdShoppingCartItemsResponse>> HandleAsync(GetByIdShoppingCartItemsRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
