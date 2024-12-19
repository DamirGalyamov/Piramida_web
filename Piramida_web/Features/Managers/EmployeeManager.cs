using AutoMapper;
using Piramid.Logic.Interfaces.Repositories;
using Piramid.Logic.Interfaces.Services;
using Piramida.Logic.DtoModels.Filters;
using Piramida.Storage.Database;
using Piramida.Storage.Models;
using Piramida_web.Features.DtoModels.Employee;
using Piramida_web.Features.Interface;

namespace Piramida_web.Features.Managers
{
    public class EmployeeManager : IEmployeeManager
    {
        private readonly IMapper _mapper;
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IEmployeeService _employeeServices;
        private readonly DataContext _dataContext;

        public EmployeeManager(IEmployeeRepository employeeRepository, IEmployeeService employeeServices, DataContext dataContext, IMapper mapper)
        {
            _mapper = mapper;
            _employeeRepository = employeeRepository;
            _employeeServices = employeeServices;
            _dataContext = dataContext;
        }

        public void Creat(EditEmployeeDto editEmployee)
        {
            var Employee = _mapper.Map<Employee>(editEmployee);

            //System.Console.WriteLine($"Случайный Guid: {Employee.Id}");

            _employeeRepository.Create(_dataContext, Employee);

            _dataContext.SaveChanges();

        }

        public void Update(EditEmployeeDto editEmployee)
        {
            var Employee = _mapper.Map<Employee>(editEmployee);

            _employeeRepository.Update(_dataContext, Employee);

            _dataContext.SaveChanges();
        }

        public void Delete(Guid Id)
        {
            _employeeRepository.Delete(_dataContext, Id);
            _dataContext.SaveChanges();
        }

        public EmployeeDto GetEmployee(Guid Id)
        {
            var employee = _employeeRepository.GetByID(_dataContext, Id);
            return _mapper.Map<EmployeeDto>(employee);
        }

        public EmployeeDto[] GetListEmployee(EmployeeFilterDto employeeFilter)
        {
            var employee = _employeeServices.GetEmployeeQueryable(_dataContext, employeeFilter, true)
                .Select(x => new EmployeeDto
                {
                    Id = x.Id,
                    Name = x.Name,
                    Section = x.Section

                }).ToArray();
            return employee;
        }
    }
}
