namespace EventManagementSystem.Dtos
{
    public class EventDto
    {
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string EventDate { get; set; } = string.Empty;
        public string Location { get; set; } = string.Empty;
        public int CreatedBy { get; set; }
    }
}