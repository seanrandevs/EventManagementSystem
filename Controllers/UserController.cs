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

    // Get Users
    [HttpGet("getusers")]
    public ActionResult<IEnumerable<User>> GetUsers()
    {
        var users = _userRepository.GetUsers();
        if (users == null || !users.Any())
        {
            return NotFound();
        }
        return Ok(users);
    }
    // Get Single User
    [HttpGet("{id}")]
    public ActionResult<User> GetUserById(int id)
    {
        var user = _userRepository.GetUserById(id);
        if (user == null)
        {
            return NotFound(); // Return 404 if the user is not found
        }
        return Ok(user); // Return the user object
    }
    // Add User
    [HttpPost("adduser")]
    public ActionResult<User> AddUser([FromBody] UserDto userDto)
    {
        if (userDto == null || string.IsNullOrEmpty(userDto.Password))
        {
            return BadRequest("User or password is null.");
        }

        var user = new User
        {
            Username = userDto.Username,
            Email = userDto.Email,
            Role = userDto.Role
        };

        var createdUser = _userRepository.AddUser(user, userDto.Password);

        return CreatedAtAction(nameof(GetUserById), new { id = createdUser.Id }, createdUser);
    }
}
