using CA.Domain;
using MediatR;
using System.Collections.Generic;

namespace CA.Application.CompanyContext.Queries.SearchEmployees
{
    public class SearchEmployeesQuery : IRequest<List<Employee>>
    {
        public string Name { get; set; }

        public string NameSearchStrategy { get; set; }

        public int Age { get; set; }

        public string AgeSearchStrategy { get; set; }
    }
}
