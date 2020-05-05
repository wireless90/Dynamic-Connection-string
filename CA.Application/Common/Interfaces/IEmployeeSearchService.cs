using CA.Domain;
using System.Linq;

namespace CA.Application.Common.Interfaces
{
    public interface IEmployeeSearchService
    {
        IQueryable<Employee> Execute(string strategyName);
    }
}
