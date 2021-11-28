using Ardalis.ApiEndpoints;
using GameStart.Core.Entities;
using GameStart.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace GameStart.Endpoints.Categories
{
    public class Update : BaseAsyncEndpoint
    .WithRequest<UpdateCategoryRequest>
    .WithResponse<UpdateCategoryResponse>
    {
        private readonly IRepository<Category> _categoryRepository;

        public Update(IRepository<Category> categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }
        [HttpPut("api/categories")]
        [SwaggerOperation(
           Summary = "Updates a Category",
           Description = "Updates a Category",
           OperationId = "categories.update",
           Tags = new[] { "Category Endpoints" })
        ]
        public override async Task<ActionResult<UpdateCategoryResponse>> HandleAsync(UpdateCategoryRequest request, CancellationToken cancellationToken = default)
        {
            var response = new UpdateCategoryResponse(request.CorrelationId());
            var item = await _categoryRepository.GetByIdAsync(request.Id, cancellationToken);

            item.UpdateCategory(request.Name, request.Description);

            await _categoryRepository.UpdateAsync(item, cancellationToken);
            var dto = new CategoryDTO
            {
                Id = request.Id,
                Name = request.Name,
                Description = request.Description
            };
            response.Category = dto;
            return response;
        }
    }
}
