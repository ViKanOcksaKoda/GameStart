using Ardalis.ApiEndpoints;
using GameStart.Core.Entities;
using GameStart.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace GameStart.Endpoints.Products
{
    public class Update : BaseAsyncEndpoint
    .WithRequest<UpdateProductRequest>
    .WithResponse<UpdateProductResponse>
    {
        private readonly IRepository<Product> _itemRepository;

        public Update(IRepository<Product> itemRepository)
        {
            _itemRepository = itemRepository;
        }

        [HttpPut("api/products")]
        [SwaggerOperation(
            Summary = "Updates a Product",
            Description = "Updates a Product",
            OperationId = "products.update",
            Tags = new[] { "Product Endpoints" })
        ]
        public override async Task<ActionResult<UpdateProductResponse>> HandleAsync(UpdateProductRequest request, CancellationToken cancellationToken)
        {
            var response = new UpdateProductResponse(request.CorrelationId());

            var existingItem = await _itemRepository.GetByIdAsync(request.Id, cancellationToken);

            existingItem.UpdateDetails(request.Name, request.Description, request.Price, request.StockBalance);
            existingItem.UpdateCategory(request.CategoryId);

            await _itemRepository.UpdateAsync(existingItem, cancellationToken);

            var dto = new ProductDTO
            {
                Id = existingItem.Id,
                CategoryId = existingItem.CategoryId,
                Description = existingItem.Description,
                Name = existingItem.Name,
                Price = existingItem.Price,
                StockBalance = existingItem.StockBalance
            };
            response.Product = dto;
            return response;
        }
    }
}
