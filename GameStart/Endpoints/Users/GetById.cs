using Ardalis.ApiEndpoints;
using GameStart.Core.Entities;
using GameStart.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace GameStart.Endpoints.Users
{
    public class GetById : BaseAsyncEndpoint
    .WithRequest<GetByIdUserRequest>
    .WithResponse<GetByIdUserResponse>
    {
        private readonly IRepository<User> _userRepository;

        public GetById(IRepository<User> userRepository)
        {
            _userRepository = userRepository;
        }
        [HttpGet("api/users/{UserId}")]
        [SwaggerOperation(
            Summary = "Get a new User by Id",
            Description = "Gets a new User by Id",
            OperationId = "users.GetById",
            Tags = new[] { "User Endpoints" })
        ]
        public override async Task<ActionResult<GetByIdUserResponse>> HandleAsync([FromRoute] GetByIdUserRequest request, CancellationToken cancellationToken = default)
        {
            var response = new GetByIdUserResponse(request.CorrelationId());

            var user = await _userRepository.GetByIdAsync(request.UserId, cancellationToken);
            if (user == null) return NotFound();

            response.User = new UserDTO
            {
                Id = user.Id,
                UserName = user.UserName,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Role = user.Role
            };

            return response;
        }
    }
}
