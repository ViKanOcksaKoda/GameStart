namespace GameStart.Endpoints.Users
{
    public class GetByIdUserRequest : BaseRequest
    {
        public int UserId { get; set; }
    }
}