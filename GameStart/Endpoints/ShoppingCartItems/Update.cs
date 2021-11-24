using Ardalis.ApiEndpoints;
using Microsoft.AspNetCore.Mvc;

namespace GameStart.Endpoints.ShoppingCartItems
{
    public class Update : BaseAsyncEndpoint
        .WithRequest<UpdateShoppingCartItemsRequest>
        .WithResponse<UpdateShoppingCartItemsResponse>
    {
        public override Task<ActionResult<UpdateShoppingCartItemsResponse>> HandleAsync(UpdateShoppingCartItemsRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
