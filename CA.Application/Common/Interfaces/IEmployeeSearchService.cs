using CA.Domain;
using System.Linq;

namespace CA.Application.Common.Interfaces
{
    public interface IEmployeeSearchService
    {
        IEmployeeSearchService SearchName(string strategyName, string value);

        IEmployeeSearchService SearchAge(string strategyName, int value);

        IQueryable<Employee> AsQueryable();
    }
}
