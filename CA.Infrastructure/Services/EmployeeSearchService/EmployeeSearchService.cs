using CA.Application.Common.Interfaces;
using CA.Domain;
using System;
using System.Linq;

namespace CA.Infrastructure.Services.EmployeeSearchService
{
    public class EmployeeSearchService : IEmployeeSearchService
    {
        private readonly Func<string, Func<string, string, bool>> _employeeNameSearchStrategyFactory;
        private readonly Func<string, Func<int, int, bool>> _employeeAgeSearchStrategyFactory;
        private readonly ICompanyDbContext _companyDbContext;
        private IQueryable<Employee> query;

        public EmployeeSearchService(ICompanyDbContext companyDbContext,
            Func<string, Func<string, string, bool>> employeeNameSearchStrategyFactory,
            Func<string, Func<int, int, bool>> employeeAgeSearchStrategyFactory)
        {
            _employeeNameSearchStrategyFactory = employeeNameSearchStrategyFactory;
            _employeeAgeSearchStrategyFactory = employeeAgeSearchStrategyFactory;
            _companyDbContext = companyDbContext;
            query = _companyDbContext.Employees;
        }

        public IQueryable<Employee> AsQueryable()
        {
            return query;
        }

        public IEmployeeSearchService SearchAge(string strategyName, int value)
        {
            var searchStrategy = _employeeAgeSearchStrategyFactory(strategyName);
            query = query.Where(x => searchStrategy(x.Age, value));
            return this;
        }

        public IEmployeeSearchService SearchName(string strategyName, string value)
        {
            var searchStrategy = _employeeNameSearchStrategyFactory(strategyName);
            query = query.Where(x => searchStrategy(x.Name, value));

            return this;
        }
    }
}
