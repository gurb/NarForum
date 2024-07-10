namespace Application.Contracts.Hubs
{
    public interface ITrackHub
    {
        Task ReceiveActiveUserCounter(int counter);
        Task ReceiveActiveUsers(string jsonStr);
    }
}
