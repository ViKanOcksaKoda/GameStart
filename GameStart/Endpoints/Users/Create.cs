using Ardalis.ApiEndpoints;
using GameStart.Core.Entities;
using GameStart.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace GameStart.Endpoints.Users
{
    public class Create : BaseAsyncEndpoint
    .WithRequest<CreateUserRequest>
    .WithResponse<CreateUserResponse>
    {
        private readonly IRepository<User> _userRepository;

        public Create(IRepository<User> userRepository)
        {
            _userRepository = userRepository;
        }
        [HttpPost("api/users")]
        [SwaggerOperation(
            Summary = "Creates a new User",
            Description = "Creates a new User",
            OperationId = "users.create",
            Tags = new[] { "User Endpoints" })
        ]
        public override async Task<ActionResult<CreateUserResponse>> HandleAsync(CreateUserRequest request, CancellationToken cancellationToken)
        {
            var response = new CreateUserResponse(request.CorrelationId());

            var newUser = new User(request.UserName, request.Password, request.Role, request.FirstName, request.LastName);
            newUser = await _userRepository.AddAsync(newUser, cancellationToken);

            var dto = new UserDTO
            {
                Id = newUser.Id,
                UserName = newUser.UserName,
                Password = newUser.Password,
                Role = newUser.Role,
                FirstName = newUser.FirstName,
                LastName = newUser.LastName
            };
            response.User = dto;
            return response;
        }
    }
}
