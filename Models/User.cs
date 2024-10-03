namespace EventManagementSystem.Models
{
    public partial class User
    {
        public int Id { get; set; }
        public string Username { get; set; } = string.Empty;
        public string PasswordHash { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Role { get; set; } = string.Empty;

        public User(string username, string passwordHash, string email, string role)
        {
            Username = username;
            PasswordHash = passwordHash;
            Email = email;
            Role = role;
        }
    }
}

