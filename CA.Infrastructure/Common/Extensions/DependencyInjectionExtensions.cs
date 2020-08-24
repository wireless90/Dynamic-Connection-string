using Microsoft.Extensions.DependencyInjection;

namespace CA.Infrastructure.Common.Extensions
{
    public static class DependencyInjectionExtensions
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection serviceDescriptors)
        {
            return serviceDescriptors;
        }
    }
    
}
