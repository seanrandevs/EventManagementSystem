using System.ComponentModel.DataAnnotations;

namespace EventManagementSystem.Models
{
    public class User
    {
        public int Id { get; set; }

        [Required]
        public string Username { get; set; }

        [Required]
        public string PasswordHash { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Role { get; set; }

        // Parameterless constructor
        public User() { }

        // Constructor with parameters
        public User(string username, string passwordHash, string email, string role)
        {
            Username = username;
            PasswordHash = passwordHash;
            Email = email;
            Role = role;
        }
    }

}
