namespace GameStart.Endpoints.Users
{
    public class LoginUserResponse : BaseResponse
    {
        public LoginUserResponse(Guid correlationId) : base(correlationId)
        {
        }

        public LoginUserResponse()
        {
        }

        public bool LoggedIn { get; set; }
    
    }
}