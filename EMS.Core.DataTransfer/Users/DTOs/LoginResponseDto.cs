namespace EMS.Core.DataTransfer.Users.DTOs
{
    public class LoginResponseDto
    {
        public string Token { get; }
        public bool Success { get; }

        public LoginResponseDto(string token, bool success)
        {
            Token = token;
            Success = success;
        }
    }
}
