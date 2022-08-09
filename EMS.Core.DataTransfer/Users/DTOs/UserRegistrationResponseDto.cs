using System.Collections.Generic;

namespace EMS.Core.DataTransfer.Users.DTOs
{
    public class UserRegistrationResponseDto
    {
        public string Token { get; }
        public bool Success { get; }
        public List<string> Errors { get; }

        public UserRegistrationResponseDto(string token, bool success = true, List<string> errors = null)
        {
            Token = token;
            Success = success;
            Errors = errors;
        }
    }
}
