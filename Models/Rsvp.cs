namespace EventManagementSystem.Models
{
      public partial class Rsvp
    {
        public int Id { get; set; }
        public int EventId { get; set; }
        public int UserId { get; set; }
        public string Status { get; set; } = string.Empty;

        public Rsvp(int eventId, int userId, string status)
        {
            EventId = eventId;
            UserId = userId;
            Status = status;
        }
    }
}
