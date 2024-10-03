namespace EventManagementSystem.Models
{
    public partial class Event
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public DateTime EventDate { get; set; }
        public string Location { get; set; } = string.Empty;
        public string CreatedBy { get; set; } = string.Empty;

        public Event(string title, string description, DateTime eventDate, string location, string createdBy)
        {
            Title = title;
            Description = description;
            EventDate = eventDate;
            Location = location;
            CreatedBy = createdBy;
        }
    }
}
