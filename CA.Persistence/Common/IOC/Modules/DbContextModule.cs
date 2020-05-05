using Autofac;
using CA.Application.Common.Interfaces;

namespace CA.Persistence.Common.IOC.Modules
{
    public class DbContextModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.Register(c => c.Resolve<CompanyDbContext>())
                .As<ICompanyDbContext>();

            base.Load(builder);
        }
    }
}
