using Ardalis.ApiEndpoints;
using GameStart.Core.Entities;
using GameStart.Core.Interfaces;
using GameStart.Core.Specifications;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace GameStart.Endpoints.Categories
{
    public class Create : BaseAsyncEndpoint
    .WithRequest<CreateCategoryRequest>
    .WithResponse<CreateCategoryResponse>
    {
        private readonly IRepository<Category> _itemRepository;

        public Create(IRepository<Category> itemRepository)
        {
            _itemRepository = itemRepository;
        }

        [HttpPost("api/categories")]
        [SwaggerOperation(
            Summary = "Creates a new Category",
            Description = "Creates a new Category",
            OperationId = "Category.create",
            Tags = new[] { "Category Endpoints" })
        ]
        public override async Task<ActionResult<CreateCategoryResponse>> HandleAsync(CreateCategoryRequest request, CancellationToken cancellationToken)
        {
            var response = new CreateCategoryResponse(request.CorrelationId());

            var categoryNameSpecification = new CategoryNameSpecification(request.Name);
            var existingProduct = await _itemRepository.CountAsync(categoryNameSpecification, cancellationToken);
            if (existingProduct > 0)
            {
                //throw new DuplicateException($"A catalogItem with name {request.Name} already exists");
                throw new Exception($"A catalogItem with name {request.Name} already exists");
            }

            var newItem = new Category(request.Name, request.Description);
            newItem = await _itemRepository.AddAsync(newItem, cancellationToken);

            var dto = new CategoryDTO
            {
                Id = newItem.Id,
                Name = newItem.Name,
                Description = newItem.Description
            };
            response.Category = dto;
            return response;
        }
    }
}
