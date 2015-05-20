using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using Safehaus.IntranetGaming.DataLayer;
using Safehaus.IntranetGaming.DataLayer.InMemory;

namespace Safehaus.IntranetGaming.Setup
{
    public class InMemoryDataLayerAutofacModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<RoomInMemoryDataLayer>()
                .As<IRoomDataLayer>()
                .SingleInstance();
            builder.RegisterType<GameInMemoryDataLayer>()
                .As<IGameDataLayer>()
                .SingleInstance();
        }
    }
}
