using Ardalis.ApiEndpoints;
using AutoMapper;
using GameStart.Core.Entities;
using GameStart.Core.Interfaces;
using GameStart.Core.Specifications;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace GameStart.Endpoints.Products
{
    public class ListByCategory : BaseAsyncEndpoint
    .WithRequest<ListProductsByCategoryRequest>
    .WithResponse<ListProductsByCategoryResponse>
    {
        private readonly IRepository<Product> _itemRepository;
        private readonly IMapper _mapper;

        public ListByCategory(IRepository<Product> itemRepository,
            IMapper mapper)
        {
            _itemRepository = itemRepository;
            _mapper = mapper;
        }

        [HttpGet("api/products{CategoryId}")]
        [SwaggerOperation(
            Summary = "List Products by Category",
            Description = "List Products by Category",
            OperationId = "products.ListByCategory",
            Tags = new[] { "Product Endpoints" })
        ]
        public override async Task<ActionResult<ListProductsByCategoryResponse>> HandleAsync([FromQuery] ListProductsByCategoryRequest request, CancellationToken cancellationToken)
        {
            var response = new ListProductsByCategoryResponse(request.CorrelationId());

            var filterSpec = new ProductFilterSpecification(request.CategoryId);

            var items = await _itemRepository.ListAsync(filterSpec, cancellationToken);

            response.Products.AddRange(items.Select(_mapper.Map<ProductDTO>));

            return Ok(response);
        }
    }
}
