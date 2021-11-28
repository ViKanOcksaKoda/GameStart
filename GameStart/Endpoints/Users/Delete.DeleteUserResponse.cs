namespace GameStart.Endpoints.Users
{
    public class DeleteUserResponse : BaseResponse
    {
        public DeleteUserResponse(Guid correlationId) : base(correlationId)
        {
        }

        public DeleteUserResponse()
        {
        }

        public string Status { get; set; } = "Deleted";
    }
}