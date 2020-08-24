using CA.Application.CompanyContext.Queries.GetAllEmployees;
using CA.Application.CompanyContext.Queries.SearchEmployees;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading;
using System.Threading.Tasks;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CA.Web
{
    [ApiController]
    public class HomeController : ControllerBase
    {
        private readonly IMediator _mediator;

        public HomeController(IMediator mediator)
        {
            _mediator = mediator;
        }
        // GET: /<controller>/
        [HttpGet("api/v1/employees/{connectionString}")]
        public async Task<ActionResult> Index(string connectionString)
        {
            //Just hardcoding for example
            connectionString = @"Data Source=DESKTOP-S0OLDPR\SQLEXPRESS;Initial Catalog=VidlyDB;Integrated Security=True";
            System.Collections.Generic.List<Domain.Employee> result = await _mediator.Send(new GetAllEmployeesQuery() { ConnectionString = connectionString });

            return Ok(result);
        }

        // GET: /<controller>/
        [HttpGet("api/v1/employees/search/strategyA")]
        public async Task<ActionResult> EmployeeSearch(CancellationToken cancellationToken = new CancellationToken())
        {
            //Just hardcoding for example
            SearchEmployeesQuery searchEmployeesQuery = new SearchEmployeesQuery()
            {
                NameSearchStrategy = "ContainsStrategy",
                Name = "a",
                AgeSearchStrategy = "GreaterThanStrategy",
                Age = 3
            };

            System.Collections.Generic.List<Domain.Employee> result = await _mediator.Send(searchEmployeesQuery, cancellationToken);

            return Ok(result);
        }
    }
}
