using Microsoft.Extensions.DependencyInjection;

namespace CA.Persistence.Common.Extensions
{
    public static class DependencyInjectionExtensions
    {
        public static IServiceCollection AddPersistence(this IServiceCollection serviceDescriptors)
        {
            //serviceDescriptors.AddTransient<ICompanyDbContext, CompanyDbContext>();

            return serviceDescriptors;
        }
    }
}
