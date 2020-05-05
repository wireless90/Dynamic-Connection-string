using CA.Infrastructure.Common.Interfaces;
using System;
using CA.Application.Common.Interfaces;
using System.Linq;
using CA.Domain;

namespace CA.Infrastructure.Services.EmployeeSearchService
{
    public class EmployeeSearchService : IEmployeeSearchService
    {
        private readonly Func<string, IEmployeeSearchStrategy> _employeeSearchStrategyFactory;
        private readonly ICompanyDbContext _companyDbContext;

        public EmployeeSearchService(Func<string, IEmployeeSearchStrategy> employeeSearchStrategyFactory, ICompanyDbContext companyDbContext)
        {
            _employeeSearchStrategyFactory = employeeSearchStrategyFactory;
            _companyDbContext = companyDbContext;
        }

        public IQueryable<Employee> Execute(String strategyName)
        {
            return _employeeSearchStrategyFactory(strategyName).Run(_companyDbContext.Employees);
        }
    }
}
