using AutoMapper;
using EventManagementSystem.Data;
using EventManagementSystem.Models;
using Microsoft.AspNetCore.Mvc;

namespace EventManagementSystem.Controllers;

[ApiController]
[Route("api/[controller]")]
public class EventController : ControllerBase
{
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;

    public EventController(IUserRepository userRepository, IMapper mapper)
    {
        _userRepository = userRepository;
        _mapper = mapper;
    }

    // Get Users
    [HttpGet("getevents")]
    public ActionResult<IEnumerable<Event>> GetEvents()
    {
        var events = _userRepository.GetEvents();
        if (events == null || !events.Any())
        {
            return NotFound();
        }
        return Ok(events);
    }
    
}