using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using System.Diagnostics.CodeAnalysis;
using Safehaus.IntranetGaming.Contract.Fibbage.Requests;
using Safehaus.IntranetGaming.Contract.Fibbage.Responses;
using vtortola.WebSockets;
using Newtonsoft.Json;

namespace Safehaus.IntranetGaming.WebSockets
{
    [SuppressMessage ("Gendarme.Rules.Performance", "AvoidUnusedPrivateFieldsRule")]
    public class SocketManager
    {
        private IEnumerable<SocketConnection> SocketConnections;
        private CancellationToken serverCancellationToken;
        public SocketManager(CancellationToken serverCancellationToken)
        {
            this.serverCancellationToken = serverCancellationToken;
        }

        public async Task AddSocketConnection(WebSocket socketClient)
        {
            var message = await socketClient.ReadStringAsync(serverCancellationToken);
            var createUserRequest = JsonConvert.DeserializeObject<CreateUserRequest>(message);
            Guid userId = Guid.Empty;
            if (!Guid.TryParse(createUserRequest.UserId, out userId))
            {
                userId = Guid.NewGuid();
            }
            var userCreationResponse = new CreateUserResponse();
            userCreationResponse.UserId = userId;
            
            //TODO: add proper cancellation token management
            await socketClient.WriteStringAsync(JsonConvert.SerializeObject(userCreationResponse), CancellationToken.None);

        }

    }
}
