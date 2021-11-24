using Ardalis.ApiEndpoints;
using Microsoft.AspNetCore.Mvc;

namespace GameStart.Endpoints.ShoppingCartItems
{
    public class Create : BaseAsyncEndpoint
        .WithRequest<CreateShoppingCartItemsRequest>
        .WithResponse<CreateShoppingCartItemsResponse>
    {
        public override Task<ActionResult<CreateShoppingCartItemsResponse>> HandleAsync(CreateShoppingCartItemsRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
