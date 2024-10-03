using EventManagementSystem.Data;
using EventManagementSystem.Models;
using System.Collections.Generic;
using System.Linq;

namespace EventManagementSystem.Data
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _context;

        public UserRepository(AppDbContext context)
        {
            _context = context;
        }

        public IEnumerable<User> GetUsers()
        {
            return _context.Users.ToList(); // Fetch all users from the database
        }
    }
}


