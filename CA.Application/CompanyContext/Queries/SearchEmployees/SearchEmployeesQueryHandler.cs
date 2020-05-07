using CA.Application.Common.Interfaces;
using CA.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace CA.Application.CompanyContext.Queries.SearchEmployees
{
    public class SearchEmployeesQueryHandler : IRequestHandler<SearchEmployeesQuery, List<Employee>>
    {
        private readonly IEmployeeSearchService _employeeSearchService;

        public SearchEmployeesQueryHandler(IEmployeeSearchService employeeSearchService)
        {
            _employeeSearchService = employeeSearchService;
        }

        public async Task<List<Employee>> Handle(SearchEmployeesQuery request, CancellationToken cancellationToken)
        {
            return await _employeeSearchService
                .SearchName(request.NameSearchStrategy, request.Name)
                .SearchAge(request.AgeSearchStrategy, request.Age)
                .AsQueryable()
                .ToListAsync(cancellationToken);
        }
    }
}
