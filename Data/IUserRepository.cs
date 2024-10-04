using EventManagementSystem.Models;
using System.Collections.Generic;
//using EventManagementSystem.Data;

namespace EventManagementSystem.Data
{
    public interface IUserRepository
    {
        IEnumerable<User> GetUsers();

        User GetUserById(int id);

        User AddUser(User user, string password);
    }
}

