﻿namespace GameStart.Endpoints.Users
{
    public class LoginUserResponse : BaseResponse
    {
        public LoginUserResponse(Guid correlationId) : base(correlationId)
        {
        }

        public LoginUserResponse()
        {
        }

        public int UserId { get; set; }
        public bool LoggedIn { get; set; }
        public string Role { get; set; }
    }
}