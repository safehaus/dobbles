using System;
using System.Threading;
using System.Net;
using Microsoft.Owin.Hosting;
using Safehaus.IntranetGaming.Contract;
using Safehaus.IntranetGaming.Setup;
using vtortola.WebSockets;


namespace Safehaus.IntranetGaming
{
    public class Program
    {
        private static WebSocketPool sockets = new WebSocketPool();

        static void Main(string[] args)
        {
            var startOptions = new StartOptions();
            startOptions.Urls.Add("http://+:8080");

            // Start API server.
            WebApp.Start (startOptions, (builder) => new Startup ().Configuration (builder, true));
            Console.WriteLine("Service Started");

            // Kick off websocket listener.
            var server = new WebSocketListener(new IPEndPoint(IPAddress.Any, 8081));
            var rfc6455 = new vtortola.WebSockets.Rfc6455.WebSocketFactoryRfc6455(server);
            server.Standards.RegisterStandard(rfc6455);
            server.Start();
            while (true)
            {
                CancellationTokenSource source = new CancellationTokenSource();
                WebSocket client = server.AcceptWebSocketAsync(source.Token).Result;
                sockets.AddClient(client);
            }
        }
    }
}
