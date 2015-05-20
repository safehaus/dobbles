using System;
using System.Collections.Generic;
using vtortola.WebSockets;
using System.Threading.Tasks;
using System.Threading;
using System.IO;

namespace Safehaus.IntranetGaming.Contract
{
    public class WebSocketPool
    {
        private List<WebSocket> pool = new List<WebSocket>();

        private List<Task> tasks = new List<Task>();

        public WebSocketPool()
        {
        }

        public void AddClient(WebSocket client)
        {
            pool.Add(client);
            tasks.Add(Task.Run(async () => {
                while (true)
                {
                    try {
                        Console.WriteLine("Awaiting data...");
                        CancellationTokenSource source = new CancellationTokenSource();
                        String s = await client.ReadStringAsync(source.Token).ConfigureAwait(false);
                        client.WriteString(s);
                    } catch (Exception ex) {
                        Console.WriteLine(ex.GetBaseException().Message);
                    }
                }
            }));
        }
    }
}
