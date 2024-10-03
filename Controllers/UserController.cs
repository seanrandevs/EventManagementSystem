using AutoMapper;
using EventManagementSystem.Data;
using EventManagementSystem.Models;
using Microsoft.AspNetCore.Mvc;

namespace EventManagementSystem.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserController : ControllerBase
{
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;

    public UserController(IUserRepository userRepository, IMapper mapper)
    {
        _userRepository = userRepository;
        _mapper = mapper;
    }

    // GET: api/user/getusers
    [HttpGet("getusers")]
    public ActionResult<IEnumerable<User>> GetUsers()
    {
        var users = _userRepository.GetUsers(); // This should return a list of users
        if (users == null || !users.Any())
        {
            return NotFound();
        }
        return Ok(users);
    }
}
