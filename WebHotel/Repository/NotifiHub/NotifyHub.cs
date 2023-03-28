using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;

namespace WebHotel.Repository.NotifiHub
{

    [Authorize]
    public class ChatHub : Hub<IHubClient>
    {
        private readonly static ConnectionMapping<string> _connections =
            new ConnectionMapping<string>();

        public void SendChatMessage(string whoReceive, string message)
        {
            var name = Context.User?.Claims.FirstOrDefault(a => a.Type == "UserName").Value;
            Clients.Caller.ReceiveMessage(name, message);
            foreach (var connectionID in _connections.GetConnections(whoReceive))
            {
                Clients.Client(connectionID).ReceiveMessage(name, message);
            }
        }

        public void SendChatMessageAuto(string message)
        {
            Clients.Caller.ReceiveMessage("admin", "Đã nhận tin nhắn");
        }

        public override Task OnConnectedAsync()
        {
            Console.WriteLine(Context.ConnectionId);
            var name = Context.User?.Claims.FirstOrDefault(a => a.Type == "UserName")?.Value;
            _connections.Add(name, Context.ConnectionId);
            return base.OnConnectedAsync();
        }

        public override Task OnDisconnectedAsync(Exception? exception)
        {
            var name = Context.User?.Claims.FirstOrDefault(a => a.Type == "UserName")?.Value;
            _connections.Remove(name, Context.ConnectionId);
            return base.OnDisconnectedAsync(exception);
        }
    }
}

