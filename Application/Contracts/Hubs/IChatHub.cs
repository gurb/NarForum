namespace Application.Contracts.Hubs
{
    public interface IChatHub
    {
        Task SendMessageToAll(string message);
        Task SendMessage(string userName, string message);
        Task ReceiveMessage(string userName, string message);
    }
}
