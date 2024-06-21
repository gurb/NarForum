namespace Application.Models.Identity.Hub
{
    public class ActiveUser
    {
        public string UserName { get; set; } = string.Empty;
        public string? ConnectionId { get; set; } 
    }
}
