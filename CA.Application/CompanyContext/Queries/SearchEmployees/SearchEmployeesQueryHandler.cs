using CA.Domain;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace CA.Application.CompanyContext.Queries.SearchEmployees
{
    public class SearchEmployeesQueryHandler : IRequestHandler<SearchEmployeesQuery, List<Employee>>
    {
        public SearchEmployeesQueryHandler()
        {
        }

        public async Task<List<Employee>> Handle(SearchEmployeesQuery request, CancellationToken cancellationToken)
        {
            return null;
        }
    }
}
