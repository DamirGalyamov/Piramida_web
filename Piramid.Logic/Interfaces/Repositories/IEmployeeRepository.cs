using Piramida.Storage.Database;
using Piramida.Storage.Models;

namespace Piramid.Logic.Interfaces.Repositories
{
    public interface IEmployeeRepository
    {
        Employee Create(DataContext dataContext, Employee employee);

        Employee Update(DataContext dataContext, Employee employee);

        void Delete(DataContext dataContext, Guid isnNode);

        Employee GetByID(DataContext dataContext, Guid isnNode);
    }
}
