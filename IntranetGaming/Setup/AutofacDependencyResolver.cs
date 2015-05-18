using System;
using System.Collections.Generic;
using System.Web.Http.Dependencies;
using Autofac;
using Autofac.Core.Lifetime;

namespace Safehaus.IntranetGaming.Setup
{
    public class AutofacDependencyResolver : IDependencyResolver
    {
        public ILifetimeScope container;
        
        public AutofacDependencyResolver(ILifetimeScope container)
        {
            this.container = container;
        }

        public object GetService(Type serviceType)
        {
            return container.ResolveOptional(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            if (container.IsRegistered(serviceType))
            {
                Type resolveItems = typeof(IEnumerable<>).MakeGenericType(serviceType);
                return (IEnumerable<object>)container.Resolve(resolveItems);
            }
            else
            {
                return new object[0];
            }
        }

        public IDependencyScope BeginScope()
        {
            return new AutofacDependencyResolver(
                container.BeginLifetimeScope(MatchingScopeLifetimeTags.RequestLifetimeScopeTag));
        }

        public void Dispose()
        {
            container.Dispose();
        }
    }
}