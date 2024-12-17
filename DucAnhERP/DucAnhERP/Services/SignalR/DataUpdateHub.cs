using Microsoft.AspNetCore.SignalR;

namespace DucAnhERP.Services.SignalR
{
    public class DataUpdateHub : Hub
    {
        public async Task NotifyDataChanged()
        {
            // Gửi thông báo đến tất cả các client
            await Clients.All.SendAsync("ReceiveDataUpdate");
        }
    }
}