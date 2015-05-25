﻿using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Safehaus.IntranetGaming.Contract.Fibbage.Requests;
using Safehaus.IntranetGaming.Contract.Fibbage.Responses;
using Safehaus.IntranetGaming.Utilities;
using vtortola.WebSockets;

namespace Safehaus.IntranetGaming.WebSockets
{
    public class SocketManager
    {
        public IEnumerable<SocketConnection> SocketConnections;
        private CancellationToken serverCancellationToken;
        public SocketManager(CancellationToken serverCancellationToken)
        {
            
        }

        public async Task AddSocketConnection(WebSocket socketClient)
        {
            var message = await socketClient.ReadStringAsync(serverCancellationToken);
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

        }

    }
}