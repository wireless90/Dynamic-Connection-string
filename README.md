# Dynamic-Connection-string
Shows how to use a connection string at runtime, using Clean Architecture

### 1. Expose DatabaseFacade in ICompanyDbContext (Application Layer)
```cs 
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace CA.Application.Common.Interfaces
{
    public interface ICompanyDbContext
    {
        DbSet<Employee> Employees { get; set; }

        DatabaseFacade   DatabaseFacade { get; set; }
    }
}
```

### 2. Implement DatabaseFacade as Property in CompanyDbContext (Persistence Layer)
```cs 
namespace CA.Persistence
{
    public class CompanyDbContext : DbContext, ICompanyDbContext
    {
        public DbSet<Employee> Employees { get; set; }
        public DatabaseFacade DatabaseFacade { get; set; }

        public CompanyDbContext(DbContextOptions<CompanyDbContext> dbContextOptions)
            : base(dbContextOptions)
        {
            DatabaseFacade = Database;
            
        }

    }
}
```

### 3. Pass ConnectionString through Controller (Web Layer)
```cs 
[HttpGet("api/v1/employees/{connectionString}")]
public async Task<ActionResult> Index(string connectionString)
{
    //Just hardcoding for example
    connectionString = @"Data Source=DESKTOP-S0OLDPR\SQLEXPRESS;Initial Catalog=VidlyDB;Integrated Security=True";
    var result =  await _mediator.Send(new GetAllEmployeesQuery() { ConnectionString = connectionString });

    return Ok(result);
}
```

### 4. Change Connection String at Runtime (Application Layer)
```cs 
public class GetAllEmployeesHandler : IRequestHandler<GetAllEmployeesQuery, List<Employee>>
{
    private readonly ICompanyDbContext _companyDbContext;

    public GetAllEmployeesHandler(ICompanyDbContext companyDbContext)
    {
        //Note: Connection is not yet opened here
        _companyDbContext = companyDbContext;

    }

    public async Task<List<Employee>> Handle(GetAllEmployeesQuery request, CancellationToken cancellationToken)
    {
        //Here assign the new connection string
        _companyDbContext.DatabaseFacade.GetDbConnection().ConnectionString = request.ConnectionString;

        //Connection would only be opend when ToListAsync is called
        return await _companyDbContext.Employees.ToListAsync();
    }
}
```
