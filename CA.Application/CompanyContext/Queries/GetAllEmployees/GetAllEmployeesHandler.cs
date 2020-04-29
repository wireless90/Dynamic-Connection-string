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
            _companyDbContext = companyDbContext;
            
        }

        public async Task<List<Employee>> Handle(GetAllEmployeesQuery request, CancellationToken cancellationToken)
        {
            _companyDbContext.DatabaseFacade.GetDbConnection().ConnectionString = request.ConnectionString;

            return await _companyDbContext.Employees.ToListAsync();
        }
    }
}
