using CA.Domain;
using MediatR;
using System.Collections.Generic;

namespace CA.Application.CompanyContext.Queries.GetAllEmployees
{
    /// <summary>
    ///     <Description>
    ///         Gets all the employees from the database
    ///     </Description>
    /// </summary>
    public class GetAllEmployeesQuery : IRequest<List<Employee>>
    {
        public string ConnectionString { get; set; }
    }
}
