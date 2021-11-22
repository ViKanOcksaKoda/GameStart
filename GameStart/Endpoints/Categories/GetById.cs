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
        private readonly IRepository<Category> _categoryRepository;

        public GetById(IRepository<Category> categoryRepository)
        {
            _categoryRepository = categoryRepository;
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
            var item = await _categoryRepository.GetByIdAsync(request.CategoryId, cancellationToken);

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
