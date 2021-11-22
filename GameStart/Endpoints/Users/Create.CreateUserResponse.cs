namespace GameStart.Endpoints.Users
{
    public class CreateUserResponse : BaseResponse
    {
        public CreateUserResponse(Guid correlationId) : base(correlationId)
        {
        }

        public CreateUserResponse()
        {
        }

        public UserDTO User { get; set; }
    }
}