using Ardalis.ApiEndpoints;
using GameStart.Core.Entities;
using GameStart.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace GameStart.Endpoints.Categories
{
    public class GetById : BaseAsyncEndpoint
    .WithRequest<GetByIdCategoryRequest>
    .WithResponse<GetByIdCategoryResponse>
    {
        private readonly IRepository<Category> _itemRepository;

        public GetById(IRepository<Category> itemRepository)
        {
            _itemRepository = itemRepository;
        }
        [HttpGet("api/categories/{CategoryId}")]
        [SwaggerOperation(
            Summary = "Get a Category by Id",
            Description = "Gets a Category by Id",
            OperationId = "categories.GetById",
            Tags = new[] { "Category Endpoints" })
        ]
        public override async Task<ActionResult<GetByIdCategoryResponse>> HandleAsync([FromRoute] GetByIdCategoryRequest request, CancellationToken cancellationToken = default)
        {
            var response = new GetByIdCategoryResponse(request.CorrelationId());
            var item = await _itemRepository.GetByIdAsync(request.CategoryId, cancellationToken);

            if (item == null) return NotFound();

            response.Category = new CategoryDTO
            {
                Id = item.Id,
                Name = item.Name,
                Description = item.Description
            };
            return Ok(response);
        }
    }
}
