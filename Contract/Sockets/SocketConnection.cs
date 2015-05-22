using System;
using System.Threading;
using System.Threading.Tasks;
using vtortola.WebSockets;

namespace Safehaus.IntranetGaming.Contract.Sockets
{
    public class SocketConnection
    {
        public Guid UserId { get; private set; }
        private WebSocket SocketClient { get; set; }

        private CancellationTokenSource ReaderSource;
        private Task ReaderTask;

        public SocketConnection(Guid userId, WebSocket client)
        {
            UserId = userId;
            SocketClient = client;
        }

        public void StartReader()
        {
            ReaderSource = new CancellationTokenSource();
            ReaderTask = Task.Run(async () =>
            {
                string result;
                while(SocketClient.IsConnected)
                {
                    result = await SocketClient.ReadStringAsync(ReaderSource.Token);
                    Console.WriteLine("[{0}] {1}", UserId, result);
                }
            }, ReaderSource.Token);
        }

        public void Stop()
        {
            ReaderSource.Cancel();
        }
    }
}
