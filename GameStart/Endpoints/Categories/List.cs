using Ardalis.ApiEndpoints;
using AutoMapper;
using GameStart.Core.Entities;
using GameStart.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace GameStart.Endpoints.Categories
{
    public class List : BaseAsyncEndpoint
    .WithoutRequest
    .WithResponse<ListCategoriesResponse>
    {
        private readonly IRepository<Category> _categoryRepository;
        private readonly IMapper _mapper;

        public List(IRepository<Category> categoryRepository,
            IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        [HttpGet("api/categories")]
        [SwaggerOperation(
            Summary = "List Categories",
            Description = "List Categories",
            OperationId = "categories.List",
            Tags = new[] { "Category Endpoints" })
        ]
        public override async Task<ActionResult<ListCategoriesResponse>> HandleAsync(CancellationToken cancellationToken)
        {
            var response = new ListCategoriesResponse();

            var items = await _categoryRepository.ListAsync(cancellationToken);

            response.Categories.AddRange(items.Select(_mapper.Map<CategoryDTO>));

            return Ok(response);
        }
    }
}
