using Ardalis.ApiEndpoints;
using GameStart.Core.Entities;
using GameStart.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace GameStart.Endpoints.Categories
{
    public class Delete : BaseAsyncEndpoint
        .WithRequest<DeleteCategoryRequest>
        .WithResponse<DeleteCategoryResponse>
    {
        private readonly IRepository<Category> _itemRepository;

        public Delete(IRepository<Category> itemRepository)
        {
            _itemRepository = itemRepository;
        }

        [HttpDelete("api/category/{CategoryId}")]
        [SwaggerOperation(
            Summary = "Deletes a Category",
            Description = "Deletes a Category",
            OperationId = "categories.Delete",
            Tags = new[] { "Category Endpoints" })
        ]
        public override async Task<ActionResult<DeleteCategoryResponse>> HandleAsync(DeleteCategoryRequest request, CancellationToken cancellationToken = default)
        {
            var response = new DeleteCategoryResponse(request.CorrelationId());

            var itemToDelete = await _itemRepository.GetByIdAsync(request.CategoryId, cancellationToken);
            if (itemToDelete is null) return NotFound();

            await _itemRepository.DeleteAsync(itemToDelete, cancellationToken);

            return Ok(response);
        }
    }
}
