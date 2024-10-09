using AutoMapper;
using EventManagementSystem.Data;
using EventManagementSystem.Models;
using EventManagementSystem.Dtos;
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

    // Get Event
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

    // Create Event
    [HttpPost("addevent")]
    public ActionResult<Event> CreateEvent([FromBody] EventDto eventDto)
    {
        if (eventDto == null)
        {
            return BadRequest("Event data is null.");
        }

        var newEvent = new Event(
            eventDto.Title,
            eventDto.Description,
            eventDto.EventDate,
            eventDto.Location,
            eventDto.CreatedBy
        );

        // Add the event to the repository (this step assumes you have a method to save the event)
        _userRepository.AddEvent(newEvent);

        // Return a 201 Created response
        return CreatedAtAction(nameof(GetEvents), new { id = newEvent.Id }, newEvent);
    }

    // Update Event
    [HttpPut("{id}")]
    public IActionResult UpdateEvent(int id, [FromBody] EventUpdateDto eventDto)
    {
        var existingEvent = _userRepository.GetEventById(id);
        if (existingEvent == null)
        {
            return NotFound($"Event with ID {id} not found.");
        }

        // Use AutoMapper to map updated values from the DTO
        _mapper.Map(eventDto, existingEvent);

        _userRepository.UpdateEvent(existingEvent);

        return NoContent(); // Return 204 status, indicating success without a body
    }

}