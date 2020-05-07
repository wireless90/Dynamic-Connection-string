using Autofac;
using CA.Application.Common.Interfaces;
using CA.Infrastructure.Common.IOC.Factories;
using CA.Infrastructure.Services.EmployeeSearchService;
using System;

namespace CA.Infrastructure.Common.IOC.Modules
{
    public class EmployeeSearchServiceModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.Register<Func<string, Func<string,string, bool>>>(context =>
            {
                IComponentContext componentContext = context.Resolve<IComponentContext>();
                return (strategyName) =>
                {
                    return EmployeeSearchStrategyFactory.GetStringStrategy(strategyName);
                };
            });

            builder.Register<Func<string, Func<int, int, bool>>>(context =>
            {
                IComponentContext componentContext = context.Resolve<IComponentContext>();
                return (strategyName) =>
                {
                    return EmployeeSearchStrategyFactory.GetIntStrategy(strategyName);
                };
            });

            builder.RegisterType<EmployeeSearchService>()
                .As<IEmployeeSearchService>();



            base.Load(builder);
        }
    }
}
