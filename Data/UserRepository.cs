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
            _context.SaveChanges();

            return user;
        }

        // Events
        public IEnumerable<Event> GetEvents()
        {
            return _context.Events.ToList(); // Fetch all events from the database
        }

        public Event AddEvent(Event newEvent)
        {
            _context.Events.Add(newEvent);
            _context.SaveChanges();
            return newEvent; // Return the added event object
        }

        public Event GetEventById(int id)
        {
            return _context.Events.FirstOrDefault(e => e.Id == id);
        }

        public void UpdateEvent(Event eventToUpdate)
        {
            _context.Events.Update(eventToUpdate);
            _context.SaveChanges();
        }

        // Rsvps
        public IEnumerable<Rsvp> GetRsvps()
        {
            return _context.Rsvps.ToList(); // Fetch all events from the database
        }

        public Rsvp AddRsvp(Rsvp newRsvp)
        {
            _context.Rsvps.Add(newRsvp); // Add the new RSVP to the database
            _context.SaveChanges();
            return newRsvp; // Return the created RSVP
        }
        public Rsvp GetRsvpByEventAndUser(int eventId, int userId)
        {
            return _context.Rsvps.FirstOrDefault(r => r.EventId == eventId && r.UserId == userId);
        }

        public void UpdateRsvp(Rsvp rsvp)
        {
            _context.Rsvps.Update(rsvp);
            _context.SaveChanges(); // Save changes to the database
        }
    }
}


