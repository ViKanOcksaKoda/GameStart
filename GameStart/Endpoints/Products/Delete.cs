using Ardalis.ApiEndpoints;
using GameStart.Core.Entities;
using GameStart.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace GameStart.Endpoints.Products
{
    public class Delete : BaseAsyncEndpoint
    .WithRequest<DeleteProductRequest>
    .WithResponse<DeleteProductResponse>
    {
        private readonly IRepository<Product> _itemRepository;

        public Delete(IRepository<Product> itemRepository)
        {
            _itemRepository = itemRepository;
        }

        [HttpDelete("api/products/{ProductId}")]
        [SwaggerOperation(
            Summary = "Deletes a Product",
            Description = "Deletes a Product",
            OperationId = "products.Delete",
            Tags = new[] { "Product Endpoints" })
        ]
        public override async Task<ActionResult<DeleteProductResponse>> HandleAsync([FromRoute] DeleteProductRequest request, CancellationToken cancellationToken)
        {
            var response = new DeleteProductResponse(request.CorrelationId());

            var itemToDelete = await _itemRepository.GetByIdAsync(request.ProductId, cancellationToken);
            if (itemToDelete is null) return NotFound();

            await _itemRepository.DeleteAsync(itemToDelete, cancellationToken);

            return Ok(response);
        }
    }
}
