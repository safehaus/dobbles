using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;

namespace Safehaus.IntranetGaming.Contract.Sockets
{
    public class SocketManagementAutofacModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<WebSocketManager>().SingleInstance();
            builder.RegisterType<SocketListeningService>().AsImplementedInterfaces().SingleInstance();
        }
    }
}
