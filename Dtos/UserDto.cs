namespace EventManagementSystem.Dtos
{
    public class UserDto
    {
        public string Username { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty; // Ensure password is included
        public string Email { get; set; } = string.Empty;
        public string Role { get; set; } = string.Empty;
    }
}