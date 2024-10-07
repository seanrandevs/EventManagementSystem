using EventManagementSystem.Data;
using EventManagementSystem.Models;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;
using System.Linq;

namespace EventManagementSystem.Data
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _context;
        private readonly PasswordHasher<User> _passwordHasher;

        public UserRepository(AppDbContext context)
        {
            _context = context;
            _passwordHasher = new PasswordHasher<User>();
        }

        // Users
        public IEnumerable<User> GetUsers()
        {
            return _context.Users.ToList(); // Fetch all users from the database
        }

        public User GetUserById(int id) // Fetch user by ID
        {
            return _context.Users.FirstOrDefault(u => u.Id == id); // Use LINQ to search for the user by ID
        }

        public User AddUser(User user, string password)
        {
            // Hash the password and store it in PasswordHash
            user.PasswordHash = _passwordHasher.HashPassword(user, password);

            _context.Users.Add(user);
            _context.SaveChanges(); // Ensure to call SaveChanges 

            return user;
        }

        // Events
        public IEnumerable<Event> GetEvents()
        {
            return _context.Events.ToList(); // Fetch all events from the database
        }
    }
}


