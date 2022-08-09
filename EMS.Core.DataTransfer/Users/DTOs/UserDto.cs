namespace EMS.Core.DataTransfer.Users.DTOs
{
    public class UserDto
    {
        public string Id { get; }
        public string Username { get; }
        public string FirstName { get; }
        public string LastName { get; }

        public string Email { get; }
        public string Role { get; }

        public UserDto(string id, string username, string firstName, string lastName, string email, string role)
        {
            Id = id;
            Username = username;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Role = role;
        }
    }
}
