using Ardalis.ApiEndpoints;
using GameStart.Core.Entities;
using GameStart.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace GameStart.Endpoints.Products
{
    public class GetById : BaseAsyncEndpoint
    .WithRequest<GetByIdProductRequest>
    .WithResponse<GetByIdProductResponse>
    {
        private readonly IRepository<Product> _itemRepository;

        public GetById(IRepository<Product> itemRepository)
        {
            _itemRepository = itemRepository;
        }

        [HttpGet("api/products/{ProductId}")]
        [SwaggerOperation(
            Summary = "Get a Catalog Item by Id",
            Description = "Gets a Catalog Item by Id",
            OperationId = "catalog-items.GetById",
            Tags = new[] { "CatalogItemEndpoints" })
        ]
        public override async Task<ActionResult<GetByIdProductResponse>> HandleAsync([FromRoute] GetByIdProductRequest request, CancellationToken cancellationToken)
        {
            var response = new GetByIdProductResponse(request.CorrelationId());

            var item = await _itemRepository.GetByIdAsync(request.ProductId, cancellationToken);
            if (item is null) return NotFound();

            response.Product = new ProductDTO
            {
                Id = item.Id,
                CategoryId = item.CategoryId,
                Description = item.Description,
                Name = item.Name,
                Price = item.Price,
                StockBalance = item.StockBalance
            };
            return Ok(response);
        }
    }
}
