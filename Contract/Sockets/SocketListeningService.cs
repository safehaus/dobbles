using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Safehaus.IntranetGaming.Contract.Shared;
using vtortola.WebSockets;

namespace Safehaus.IntranetGaming.Contract.Sockets
{
    internal class SocketListeningService : IBackgroundService
    {
        private WebSocketListener SocketServer;
        private WebSocketManager SocketManager;
        public CancellationTokenSource GlobalCancellationTokenSource;

        public SocketListeningService(WebSocketManager socketManager)
        {
            SocketManager = socketManager;
            GlobalCancellationTokenSource = new CancellationTokenSource();

            SocketServer = new WebSocketListener(new IPEndPoint(IPAddress.Any, 8081));
            var rfc6455 = new vtortola.WebSockets.Rfc6455.WebSocketFactoryRfc6455(SocketServer);
            SocketServer.Standards.RegisterStandard(rfc6455);
        }

        public async Task Run()
        {
            SocketServer.Start();
            try
            {
                while (true)
                {
                    WebSocket client = await SocketServer.AcceptWebSocketAsync(GlobalCancellationTokenSource.Token);
                    await SocketManager.AddSocketConnection(client);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
           
        }
    }
}
