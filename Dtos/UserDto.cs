namespace EventManagementSystem.Models
{
    public class UserDto
    {
        public string Username { get; set; }
        public string Password { get; set; } // Unhashed password
        public string Email { get; set; }
        public string Role { get; set; } 
    }
}