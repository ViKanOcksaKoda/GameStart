using Ardalis.ApiEndpoints;
using AutoMapper;
using GameStart.Core.Entities;
using GameStart.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace GameStart.Endpoints.Users
{
    public class List : BaseAsyncEndpoint
     .WithoutRequest
    .WithResponse<ListUsersResponse>
    {
        private readonly IRepository<User> _userRepository;
        private readonly IMapper _mapper;

        public List(IRepository<User> userRepository, IMapper mapper = null)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        [HttpGet("api/users")]
        [SwaggerOperation(
            Summary = "List Users",
            Description = "List Users",
            OperationId = "users.List",
            Tags = new[] { "User Endpoints" })
        ]
        public override async Task<ActionResult<ListUsersResponse>> HandleAsync(CancellationToken cancellationToken)
        {
            var response = new ListUsersResponse();
            var users = await _userRepository.ListAsync(cancellationToken);

            response.Users.AddRange(users.Select(_mapper.Map<UserDTO>));
            return Ok(response);
        }
    }
}
