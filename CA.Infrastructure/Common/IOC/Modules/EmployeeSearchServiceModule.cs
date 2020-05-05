using Autofac;
using CA.Application.Common.Interfaces;
using CA.Infrastructure.Common.Interfaces;
using CA.Infrastructure.Services.EmployeeSearchService;
using System;

namespace CA.Infrastructure.Common.IOC.Modules
{
    public class EmployeeSearchServiceModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<EmployeeSearchStrategyA>()
                .AsSelf();
            
            builder.RegisterType<EmployeeSearchStrategyB>()
                .AsSelf();

            builder.Register<Func<string, IEmployeeSearchStrategy>>(context =>
            {
                IComponentContext componentContext = context.Resolve<IComponentContext>();
                return (strategyName) =>
                {
                    switch(strategyName)
                    {
                        case "A":
                            return componentContext.Resolve<EmployeeSearchStrategyA>();
                        case "B":
                            return componentContext.Resolve<EmployeeSearchStrategyB>();
                        default:
                            throw new ArgumentException($"Invalid strategy: {strategyName}");
                    }
                };
            });

            builder.RegisterType<EmployeeSearchService>()
                .As<IEmployeeSearchService>();



            base.Load(builder);
        }
    }
}
