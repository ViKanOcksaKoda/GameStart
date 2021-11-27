namespace GameStart.Endpoints.Users
{
    public class LoginUserRequest : BaseRequest
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}