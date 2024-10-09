using AutoMapper;
using EventManagementSystem.Data;
using EventManagementSystem.Models;
using Microsoft.AspNetCore.Mvc;
using EventManagementSystem.Dtos;


namespace EventManagementSystem.Controllers;

[ApiController]
[Route("api/[controller]")]
public class RsvpController : ControllerBase
{
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;

    public RsvpController(IUserRepository userRepository, IMapper mapper)
    {
        _userRepository = userRepository;
        _mapper = mapper;
    }

    // Get RSVPs
    [HttpGet("getrsvps")]
    public ActionResult<IEnumerable<Rsvp>> GetRsvps()
    {
        var rsvps = _userRepository.GetRsvps();
        if (rsvps == null || !rsvps.Any())
        {
            return NotFound();
        }
        return Ok(rsvps);
    }

    // Post RSVP
    [HttpPost("postrsvp")]
    public ActionResult<Rsvp> PostRsvp([FromBody] RsvpsDto rsvpsDto)
    {
        if (rsvpsDto == null)
        {
            return BadRequest("RSVP data is null");
        }

        var rsvp = _mapper.Map<Rsvp>(rsvpsDto); // Map DTO to the model

        var createdRsvp = _userRepository.AddRsvp(rsvp); // Add RSVP to the database

        return CreatedAtAction(nameof(GetRsvps), new { id = createdRsvp.Id }, createdRsvp); // Return created RSVP
    }
    // Update Rsvp
    [HttpPut("{eventId}/{userId}")]
    public IActionResult UpdateRsvpStatus(int eventId, int userId, [FromBody] UpdateRsvpStatusDto updateRsvpDto)
    {
        var rsvp = _userRepository.GetRsvpByEventAndUser(eventId, userId);
        if (rsvp == null)
        {
            return NotFound($"RSVP not found for Event ID {eventId} and User ID {userId}.");
        }

        // Update the status
        rsvp.Status = updateRsvpDto.Status;

        _userRepository.UpdateRsvp(rsvp);

        return NoContent(); // Return 204 status, indicating success without a body
    }
}
