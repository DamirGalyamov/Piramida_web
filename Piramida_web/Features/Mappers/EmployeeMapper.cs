using AutoMapper;
using Piramida.Storage.Models;
using Piramida_web.Features.DtoModels.Employee;

namespace Piramida_web.Features.Mappers
{
    public class EmployeeMapper : Profile
    {
        public EmployeeMapper()
        {
            CreateMap<EmployeeDto, Employee>();
            CreateMap<Employee, EmployeeDto>();

            CreateMap<EmployeeDto[], Employee[]>();
            CreateMap<Employee[], EmployeeDto[]>();

            CreateMap<EditEmployeeDto, Employee>();
            CreateMap<Employee, EditEmployeeDto>();
        }
    }
}
