using Autofac;
using Autofac.Extensions.DependencyInjection;
using CA.Application.Common.Interfaces;
using CA.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace CA.Web.Common.IOC
{
    public static class ContainerConfig
    {
        public static  AutofacServiceProvider CreateAutofacServiceProvider(IServiceCollection serviceDescriptors)
        {
            ContainerBuilder containerBuilder = new ContainerBuilder();

            containerBuilder.Populate(serviceDescriptors);

            containerBuilder.Register(c => c.Resolve<CompanyDbContext>())
                .As<ICompanyDbContext>();


            return new AutofacServiceProvider(containerBuilder.Build());
        }
    }
}
