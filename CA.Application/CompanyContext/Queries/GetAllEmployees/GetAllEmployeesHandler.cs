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
            //Here assign the new connection string
            _companyDbContext.DatabaseFacade.GetDbConnection().ConnectionString = request.ConnectionString;

            //Connection would only be opend when ToListAsync is called
            return await _companyDbContext.Employees.ToListAsync();
        }
    }
}
