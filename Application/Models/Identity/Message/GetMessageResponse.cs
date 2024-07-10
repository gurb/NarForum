namespace Application.Models.Identity.Message
{
    public class GetMessageResponse
    {
        public List<MessageDTO> Messages { get; set; } = new List<MessageDTO>();
    }
}
