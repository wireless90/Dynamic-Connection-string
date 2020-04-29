# Dynamic-Connection-string
Shows how to use a connection string at runtime, using Clean Architecture

### 1. Expose Method to change Connection String in ICompanyDbContext (Application Layer)
```cs 
using CA.Domain;
using Microsoft.EntityFrameworkCore;

namespace CA.Application.Common.Interfaces
{
    public interface ICompanyDbContext
    {
        DbSet<Employee> Employees { get; set; }

        void SetConnectionString(string connectionString);
    }
}
```

### 2. Implement SetConnectionString method in CompanyDbContext (Persistence Layer)

Nuget to install: Microsoft.EntityFrameworkCore.Relational

```cs 
using CA.Application.Common.Interfaces;
using CA.Domain;
using Microsoft.EntityFrameworkCore;

namespace CA.Persistence
{
    public class CompanyDbContext : DbContext, ICompanyDbContext
    {
        public DbSet<Employee> Employees { get; set; }

        public CompanyDbContext(DbContextOptions<CompanyDbContext> dbContextOptions)
            : base(dbContextOptions)
        {
        }

        public void SetConnectionString(string connectionString)
        {
            Database.GetDbConnection().ConnectionString = connectionString;
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
using CA.Application.Common.Interfaces;
using CA.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace CA.Application.CompanyContext.Queries.GetAllEmployees
{
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
            //Set new connection string
            _companyDbContext.SetConnectionString(request.ConnectionString);

            //Connection would only be opend when ToListAsync is called
            return await _companyDbContext.Employees.ToListAsync();
        }
    }
}

```
