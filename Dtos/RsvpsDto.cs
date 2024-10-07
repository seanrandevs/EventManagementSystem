namespace EventManagementSystem.Dtos
{
    public class RsvpsDto
    {
        public int EventId { get; set; }
        public int UserId { get; set; }
        public string Status { get; set; } = string.Empty;
    }
}