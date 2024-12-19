using Microsoft.EntityFrameworkCore;
using Piramid.Logic.Interfaces.Repositories;
using Piramida.Storage.Database;
using Piramida.Storage.Models;

namespace Piramid.Logic.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        public Employee Create(DataContext dataContext, Employee employee)
        {
            dataContext.Employees.Add(employee);
            return employee;
        }

        public Employee Update(DataContext dataContext, Employee employee)
        {
            var employeeDB = dataContext.Employees.FirstOrDefault(x => x.Id == employee.Id)
                ?? throw new Exception($"Сотрудник с данным идентификатором {employee.Id} не найден");

            employeeDB.Id = employee.Id;
            employeeDB.Name = employee.Name;
            employeeDB.Section = employee.Section;

            return employeeDB;
        }

        public void Delete(DataContext dataContext, Guid id)
        {
            var employeeDB = dataContext.Employees.FirstOrDefault(x => x.Id == id)
                ?? throw new Exception($"Сотрудник с данным идентификатором {id} не найден");

            dataContext.Employees.Remove(employeeDB);
        }

        public Employee GetByID(DataContext dataContext, Guid id)
        {
            var employeeDB = dataContext.Employees.AsNoTracking().FirstOrDefault(x => x.Id == id)
                ?? throw new Exception($"Сотрудник с данным идентификатором {id} не найден");

            // AsNoTracking используется для экономии ресурсов, поскольку такие изменения не отслеживаются.
            return employeeDB;
        }
    }
}
