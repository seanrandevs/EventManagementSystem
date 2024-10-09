namespace EventManagementSystem.Models
{
    public partial class Event
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string EventDate { get; set; } = string.Empty;
        public string Location { get; set; } = string.Empty;
        public int CreatedBy { get; set; }

        public Event(string title, string description, string eventDate, string location, int createdBy)
        {
            Title = title;
            Description = description;
            EventDate = eventDate;
            Location = location;
            CreatedBy = createdBy;
        }
    }
}
