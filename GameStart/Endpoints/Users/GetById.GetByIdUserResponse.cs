namespace GameStart.Endpoints.Users
{
    public class GetByIdUserResponse : BaseResponse
    {
        public GetByIdUserResponse(Guid correlationId) : base(correlationId)
        {
        }

        public GetByIdUserResponse()
        {
        }

        public UserDTO User { get; set; }
    }
}