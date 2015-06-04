using System.Collections.Generic;
using System.IO;
using System.Net.Http.Formatting;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Controllers;
using Autofac;
using Autofac.Core.Lifetime;
using Microsoft.Owin.FileSystems;
using Microsoft.Owin.StaticFiles;
using Owin;
using Safehaus.IntranetGaming.Contract.Shared;
using Safehaus.IntranetGaming.Contract.Sockets;

namespace Safehaus.IntranetGaming.Setup
{
    public class Startup
    {
        public void Configuration(IAppBuilder builder, bool startFileShare = true)
        {
            var serviceBuilder = new ContainerBuilder();
            RegisterComponents(serviceBuilder);

            var serviceContainer = serviceBuilder.Build();
            StartServices(serviceContainer);
            var configuration = serviceContainer.Resolve<HttpConfiguration>();
            
            //enable cors to help with testing/debugging
            configuration.EnableCors();
            RegisterRoutes(configuration);
            if (startFileShare)
            {
                RegisterSPAFileshare(builder);
            }

            configuration.DependencyResolver = new AutofacDependencyResolver(serviceContainer);
            builder.UseWebApi(configuration);
            ObjectMappings.MapObjects();
        }

        public void StartServices(IContainer container)
        {
            var backgroundServices = container.Resolve<IEnumerable<IBackgroundService>>();
            foreach (var service in backgroundServices)
            {
                service.Run();
            }
        }

        public void RegisterComponents(ContainerBuilder builder)
        {
            //Let everything have access to one instance of a configuration
            builder.Register(ctx => new HttpConfiguration())
                .SingleInstance()
                .ExternallyOwned();
            //reflection to register controllers

            builder.RegisterAssemblyTypes(this.GetType().Assembly)
                .Where(type => !type.IsAbstract && type.IsAssignableTo<IHttpController>())
                .InstancePerMatchingLifetimeScope(MatchingScopeLifetimeTags.RequestLifetimeScopeTag);

            builder.RegisterModule<InMemoryDataLayerAutofacModule>();

            builder.RegisterModule<SocketManagementAutofacModule>();
        }

        public void RegisterRoutes(HttpConfiguration config)
        {
            config.MapHttpAttributeRoutes();
            config.Routes.MapHttpRoute("Default",
                "api/{controller}/{action}/{id}/{format}",
                new { action = RouteParameter.Optional, id = RouteParameter.Optional, format = RouteParameter.Optional });
                

            config.Formatters.Clear();
            config.Formatters.Add(new JsonMediaTypeFormatter());
        }

            
        public void RegisterSPAFileshare(IAppBuilder app)
        {
            PhysicalFileSystem staticFs = new PhysicalFileSystem(Path.Combine(
                Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location),
                "Web"));

            FileServerOptions fsOptions = new FileServerOptions
            {
                FileSystem = staticFs,
                EnableDefaultFiles = true,
            };

            fsOptions.StaticFileOptions.FileSystem = staticFs;
            fsOptions.DefaultFilesOptions.DefaultFileNames = new[] { "index.html" };
            app.UseFileServer(fsOptions);
        }
        
    }
}
