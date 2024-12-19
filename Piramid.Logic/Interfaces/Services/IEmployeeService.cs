using Piramida.Logic.DtoModels.Filters;
using Piramida.Storage.Database;
using Piramida.Storage.Models;

namespace Piramid.Logic.Interfaces.Services
{
    public interface IEmployeeService
    {
        IQueryable<Employee> GetEmployeeQueryable(DataContext dataContext, EmployeeFilterDto filter, bool AsNoTraking);
    }
}
