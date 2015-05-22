using System;
using System.Threading;
using System.Net;
using Microsoft.Owin.Hosting;
using Safehaus.IntranetGaming.Contract;
using Safehaus.IntranetGaming.Contract.Sockets;
using Safehaus.IntranetGaming.Setup;
using vtortola.WebSockets;
using WebSocket = vtortola.WebSockets.WebSocket;


namespace Safehaus.IntranetGaming
{
    public class Program
    {
        private static WebSocketManager sockets;

        static void Main(string[] args)
        {
            var startOptions = new StartOptions();
            startOptions.Urls.Add("http://+:8080");

            // Start API server.
            using (var server = WebApp.Start(startOptions, (builder) => new Startup().Configuration(builder, true)))
            {
                Console.WriteLine("Service Started");
                while (true)
                {
                    if (Console.ReadLine() == "exit")
                    {
                        break;
                    }
                }
            }
        }
    }
}
