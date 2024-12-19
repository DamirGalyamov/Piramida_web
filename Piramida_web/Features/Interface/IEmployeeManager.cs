using Piramida.Logic.DtoModels.Filters;
using Piramida_web.Features.DtoModels.Employee;

namespace Piramida_web.Features.Interface
{
    public interface IEmployeeManager
    {
        public void Creat(EditEmployeeDto editEmployee);
        public void Update(EditEmployeeDto editEmployee);
        public void Delete(Guid Id);
        public EmployeeDto GetEmployee(Guid Id);
        public EmployeeDto[] GetListEmployee(EmployeeFilterDto employeeFilter);
    }
}
