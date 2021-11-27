using Ardalis.ApiEndpoints;
using GameStart.Core.Entities;
using GameStart.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace GameStart.Endpoints.Users
{
    public class Login : BaseAsyncEndpoint
    .WithRequest<LoginUserRequest>
    .WithResponse<LoginUserResponse>
    {
        private readonly IRepository<User> _userRepository;

        public Login(IRepository<User> userRepository)
        {
            _userRepository = userRepository;
        }
        [HttpGet("api/users/login/{UserName}/{Password}")]
        [SwaggerOperation(
           Summary = "Login as user",
           Description = "login with username and password",
           OperationId = "users.login",
           Tags = new[] { "User Endpoints" })
        ]
        public override async Task<ActionResult<LoginUserResponse>> HandleAsync([FromRoute]LoginUserRequest request, CancellationToken cancellationToken = default)
        {
            var response = new LoginUserResponse();
            int thisUserId = 0;
            var users = await _userRepository.ListAsync();
            for ( int i = 0; i < users.Count; i++)
            {
                if(users[i].UserName == request.UserName && users[i].Password == request.Password)
                {
                    response.LoggedIn = true;
                    thisUserId = users[i].Id;
                }
            }
            var user = await _userRepository.GetByIdAsync(thisUserId);
            
            if(user != null)
            {
                response.UserId = user.Id;
                response.Role = user.Role;
            }
            else
            {
                throw new Exception("The username or password does not match any current user.");
            }
            
            return response;
        }
    }
}
