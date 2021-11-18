using Ardalis.ApiEndpoints;
using GameStart.Core.Entities;
using GameStart.Core.Interfaces;
using GameStart.Core.Specifications;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace GameStart.Endpoints.Products
{
    public class Create : BaseAsyncEndpoint
    .WithRequest<CreateProductRequest>
    .WithResponse<CreateProductResponse>
    {
        private readonly IRepository<Product> _itemRepository;

        public Create(IRepository<Product> itemRepository)
        {
            _itemRepository = itemRepository;
        }

        [HttpPost("api/products")]
        [SwaggerOperation(
            Summary = "Creates a new Product",
            Description = "Creates a new Product",
            OperationId = "products.create",
            Tags = new[] { "ProductsEndpoints" })
        ]
        public override async Task<ActionResult<CreateProductResponse>> HandleAsync(CreateProductRequest request, CancellationToken cancellationToken)
        {
            var response = new CreateProductResponse(request.CorrelationId());

            var productNameSpecification = new ProductNameSpecification(request.Name);
            var existingProduct = await _itemRepository.CountAsync(productNameSpecification, cancellationToken);
            if (existingProduct > 0)
            {
                //throw new DuplicateException($"A catalogItem with name {request.Name} already exists");
                throw new Exception($"A catalogItem with name {request.Name} already exists");
            }

            var newItem = new Product(request.CategoryId, request.Description, request.Name, request.Price, request.StockBalance);
            newItem = await _itemRepository.AddAsync(newItem, cancellationToken);

            var dto = new ProductDTO
            {
                Id = newItem.Id,
                CategoryId = newItem.CategoryId,
                Description = newItem.Description,
                Name = newItem.Name,
                Price = newItem.Price,
                StockBalance = newItem.StockBalance
            };
            response.Product = dto;
            return response;
        }
    }
}
