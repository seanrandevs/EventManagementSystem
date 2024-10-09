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

        IEnumerable<Event> GetEvents();
        Event AddEvent(Event newEvent);
        Event GetEventById(int id); 
        void UpdateEvent(Event eventToUpdate);

        IEnumerable<Rsvp> GetRsvps();
        Rsvp AddRsvp(Rsvp newRsvp);
        Rsvp GetRsvpByEventAndUser(int eventId, int userId);
        void UpdateRsvp(Rsvp rsvp);
    }
}

