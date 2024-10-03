using EventManagementSystem.Models;
using EventManagementSystem.Data;

public interface IUserRepository
{
    IEnumerable<User> GetUsers();
}



