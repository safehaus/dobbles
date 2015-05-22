using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Safehaus.IntranetGaming.Contract.Fibbage.Requests;
using Safehaus.IntranetGaming.Contract.Fibbage.Responses;
using Safehaus.IntranetGaming.Utilities;
using vtortola.WebSockets;

namespace Safehaus.IntranetGaming.Contract.Sockets
{
    public class WebSocketManager
    {
        public Dictionary<Guid, SocketConnection> SocketConnections;
        private CancellationTokenSource ServerCancellationSource;
        public WebSocketManager()
        {
            ServerCancellationSource = new CancellationTokenSource();
            SocketConnections = new Dictionary<Guid, SocketConnection>();
        }

        public async Task AddSocketConnection(WebSocket socketClient)
        {
            var message = await socketClient.ReadStringAsync(ServerCancellationSource.Token);
            try
            {
                var createUserRequest = message.ToObject<CreateUserRequest>();
                Guid userId = Guid.Empty;
                if (!Guid.TryParse(createUserRequest.UserId, out userId))
                {
                    userId = Guid.NewGuid();
                }
                var userCreationResponse = new CreateUserResponse();
                userCreationResponse.UserId = userId;
            
                //TODO: add proper cancellation token management
                await socketClient.WriteStringAsync(userCreationResponse.ToJsonString(), CancellationToken.None);

                if (SocketConnections.ContainsKey(userId))
                {
                    var oldSocket = SocketConnections[userId];
                    oldSocket.Stop();
                }
                var newConnection =  new SocketConnection(userId, socketClient);
                newConnection.StartReader();
                SocketConnections[userId] = newConnection;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

        }

    }
}
