using Ardalis.ApiEndpoints;
using GameStart.Core.Entities;
using GameStart.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace GameStart.Endpoints.Users
{
    public class Delete : BaseAsyncEndpoint
    .WithRequest<DeleteUserRequest>
    .WithResponse<DeleteUserResponse>
    {
        private readonly IRepository<User> _userRepository;

        public Delete(IRepository<User> userRepository)
        {
            _userRepository = userRepository;
        }
        [HttpDelete("api/users/{UserId}")]
        [SwaggerOperation(
            Summary = "Deletes a new User",
            Description = "Deletes a new User",
            OperationId = "users.delete",
            Tags = new[] { "User Endpoints" })
        ]
        public override async Task<ActionResult<DeleteUserResponse>> HandleAsync([FromRoute]DeleteUserRequest request, CancellationToken cancellationToken = default)
        {
            var response = new DeleteUserResponse(request.CorrelationId());

            var deleteUser = await _userRepository.GetByIdAsync(request.UserId, cancellationToken);
            if (deleteUser == null) return NotFound();

            await _userRepository.DeleteAsync(deleteUser);

            return Ok(response);
        }
    }
}
