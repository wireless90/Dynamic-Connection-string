using CA.Application.Common.Extensions;
using CA.Application.CompanyContext.Queries.GetAllEmployees;
using CA.Console.Common.IOC;
using CA.Infrastructure.Common.Extensions;
using CA.Persistence.Common.Extensions;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading.Tasks;

namespace CA.Console
{
    internal class Program
    {
        private static async Task Main(string[] args)
        {
            IServiceCollection serviceCollection = new ServiceCollection()
                .AddApplication()
                .AddInfrastructure()
                .AddPersistence();

            IServiceProvider serviceProvider = ContainerConfig.CreateAutofacServiceProvider(serviceCollection);

            /* 
             * If we build all ONLY using microsoft DI, do the below
             * IServiceProvider serviceProvider2 = serviceCollection.BuildServiceProvider();
             * */

            using (IServiceScope scope = serviceProvider.CreateScope())
            {
                IMediator mediator = serviceProvider.GetRequiredService<IMediator>();
                await mediator.Send(new GetAllEmployeesQuery() { ConnectionString = "asdasd" });
            }
                
        }
    }
}
