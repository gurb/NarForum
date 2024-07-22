namespace Application.Contracts.Hubs
{
    public interface IChatHub
    {
        Task SendMessageToAll(string message);
        Task SendMessage(string userName, string message);
        Task ReceiveChatHistory(string username, string message);
        Task ReceiveMessageHistory(string username, string message);
        Task ReceiveChatRequest(string fromUser, string message);
        Task ReceiveChatResponse(string fromUser, string message);
        Task ReceiveMessage(string userName, string message);
    }
}
