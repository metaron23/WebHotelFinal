﻿namespace WebHotel.Model.Authentication
{
    public class LoginResponse
    {
        public string? AccessToken { get; set; }
        public string? RefreshToken { get; set; }
    }
}