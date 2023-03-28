namespace WebHotel.Repository.NotifiHub
{
    public interface IHubClient
    {
        Task ReceiveMessage(string sender, string message);
    }
}
