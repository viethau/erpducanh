using Microsoft.AspNetCore.SignalR;

namespace DucAnhERP.Services.SignalR
{
    public class NotificationHub : Hub
    {
        public async Task SendMessage(string message)
        {
            await Clients.All.SendAsync("ReceiveMessage", message);
        }
    }
}
