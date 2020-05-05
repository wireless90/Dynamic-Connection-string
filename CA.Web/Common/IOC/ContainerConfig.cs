using Autofac;
using Autofac.Extensions.DependencyInjection;
using CA.Application.Common.Interfaces;
using CA.Infrastructure.Common.IOC;
using CA.Persistence;
using CA.Persistence.Common.IOC;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace CA.Web.Common.IOC
{
    public static class ContainerConfig
    {
        public static  AutofacServiceProvider CreateAutofacServiceProvider(IServiceCollection serviceDescriptors)
        {
            ContainerBuilder containerBuilder = new ContainerBuilder();

            containerBuilder.Populate(serviceDescriptors);

            containerBuilder
                .RegisterModule(new InfrastructureModule())
                .RegisterModule(new PersistenceModule());

            return new AutofacServiceProvider(containerBuilder.Build());
        }
    }
}
