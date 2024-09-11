namespace AdminUI.Models.TrackingLog.DTOs
{
    public class PopularHeadingDTO
    {
        public Guid Id { get; set; }
        public string? Title { get; set; }
        public int ViewCounter { get; set; }
        public DateTime DateTime { get; set; }
    }
}
