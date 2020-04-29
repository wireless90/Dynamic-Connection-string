using CA.Application.CompanyContext.Queries.GetAllEmployees;
using MediatR;
using Microsoft.AspNetCore.Mvc;
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
            var result =  await _mediator.Send(new GetAllEmployeesQuery() { ConnectionString = connectionString });

            return Ok(result);
        }
    }
}
