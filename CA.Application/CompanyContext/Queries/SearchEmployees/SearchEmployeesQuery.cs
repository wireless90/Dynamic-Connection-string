using CA.Domain;
using MediatR;
using System;
using System.Collections.Generic;

namespace CA.Application.CompanyContext.Queries.SearchEmployees
{
    public class SearchEmployeesQuery : IRequest<List<Employee>>
    {
        public String Name { get; set; }

        public String NameSearchStrategy { get; set; }

        public int Age { get; set; }

        public String AgeSearchStrategy { get; set; }
    }
}
