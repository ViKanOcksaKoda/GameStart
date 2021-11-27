using Ardalis.ApiEndpoints;
using GameStart.Core.Entities;
using GameStart.Core.Interfaces;
using GameStart.Core.Specifications;
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
        public override async Task<ActionResult<CreateUserResponse>> HandleAsync(CreateUserRequest request, CancellationToken cancellationToken = default)
        {
            var response = new CreateUserResponse(request.CorrelationId());

            var productNameSpecification = new UserNameSpecification(request.UserName);
            var existingUser = await _userRepository.CountAsync(productNameSpecification, cancellationToken);
            if (existingUser > 0)
            {
                //throw new DuplicateException($"A catalogItem with name {request.Name} already exists");
                throw new Exception($"A user with Username: {request.UserName}. Already exists");
            }

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
