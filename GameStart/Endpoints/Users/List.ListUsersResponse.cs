namespace GameStart.Endpoints.Users
{
    public class ListUsersResponse : BaseResponse
    {
        public ListUsersResponse(Guid correlationId) : base(correlationId)
        {
        }

        public ListUsersResponse()
        {
        }

        public List<UserDTO> Users { get; set; } = new List<UserDTO>();
    
    }
}