using Microsoft.AspNetCore.SignalR;
using MySqlX.XDevAPI;

namespace Rfid.Hubs
{
    public class Hubs:Hub
    {
        public async Task SendClient()
        {
            await Clients.All.SendAsync("client");
        }
    }
}
