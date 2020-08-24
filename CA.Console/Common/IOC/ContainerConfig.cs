using Autofac;
using Autofac.Extensions.DependencyInjection;
using CA.Infrastructure.Common.IOC;
using CA.Persistence.Common.IOC;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace CA.Console.Common.IOC
{
    public static class ContainerConfig
    {
        public static AutofacServiceProvider CreateAutofacServiceProvider(IServiceCollection serviceColllection)
        {
            ContainerBuilder containerBuilder = new ContainerBuilder();

            containerBuilder.Populate(serviceColllection);

            containerBuilder
                .RegisterModule(new InfrastructureModule())
                .RegisterModule(new PersistenceModule())
                .RegisterModule(new InfrastructureModule());

            return new AutofacServiceProvider(containerBuilder.Build());
        }
    }
}
