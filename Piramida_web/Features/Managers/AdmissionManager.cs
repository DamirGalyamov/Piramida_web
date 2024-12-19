using AutoMapper;
using Piramid.Logic.Interfaces.Repositories;
using Piramid.Logic.Interfaces.Services;
using Piramida.Logic.DtoModels.Filters;
using Piramida.Storage.Database;
using Piramida.Storage.Models;
using Piramida_web.Features.DtoModels.Admission;
using Piramida_web.Features.Interface;

namespace Piramida_web.Features.Managers
{
    public class AdmissionManager : IAdmissionManager
    {
        private readonly IMapper _mapper;
        private readonly IAdmissionRepository _admissionRepository;
        private readonly IAdmissionService _admissionServices;
        private readonly DataContext _dataContext;

        public AdmissionManager(IAdmissionRepository admissionRepository, IAdmissionService admissionServices, DataContext dataContext, IMapper mapper)
        {
            _mapper = mapper;
            _admissionRepository = admissionRepository;
            _admissionServices = admissionServices;
            _dataContext = dataContext;
        }

        public void Creat(EditAdmissionDto editAdmission)
        {
            var Admissions = _mapper.Map<Admission>(editAdmission);

            //System.Console.WriteLine($"Случайный Guid: {Admission.Id}");

            _admissionRepository.Create(_dataContext, Admissions);

            _dataContext.SaveChanges();

        }

        public void Update(EditAdmissionDto editAdmission)
        {
            var Admission = _mapper.Map<Admission>(editAdmission);

            _admissionRepository.Update(_dataContext, Admission);

            _dataContext.SaveChanges();
        }

        public void Delete(Guid Id)
        {
            _admissionRepository.Delete(_dataContext, Id);
            _dataContext.SaveChanges();
        }

        public AdmissionDto GetAdmission(Guid Id)
        {
            var admission = _admissionRepository.GetByID(_dataContext, Id);
            return _mapper.Map<AdmissionDto>(admission);
        }

        public AdmissionDto[] GetListAdmission(AdmissionFilterDto admissionFilter)
        {
            var admission = _admissionServices.GetAdmissionQueryable(_dataContext, admissionFilter, true)
                .Select(x => new AdmissionDto
                {
                    Id = x.Id,
                    ProductId = x.ProductId,
                    ClientId = x.ClientId,
                    EmployeeId = x.EmployeeId,
                    Time = x.Time,
                    Status = x.Status

                }).ToArray();
            return admission;
        }

        public AdmissionDto[] GetListAdmissionByClient(AdmissionFilterByClient admissionFilter)
        {
            var admission = _admissionServices.GetAdmissionQueryableByClient(_dataContext, admissionFilter, true)
                .Select(x => new AdmissionDto
                {
                    Id = x.Id,
                    ProductId = x.ProductId,
                    ClientId = x.ClientId,
                    EmployeeId = x.EmployeeId,
                    Time = x.Time,
                    Status = x.Status
                }).ToArray();
            return admission;
        }

        public AdmissionDto[] GetListAdmissionByEmployee(AdmissionFilterByEmployee admissionFilter)
        {
            var admission = _admissionServices.GetAdmissionQueryableByEmployee(_dataContext, admissionFilter, true)
                .Select(x => new AdmissionDto
                {
                    Id = x.Id,
                    ProductId = x.ProductId,
                    ClientId = x.ClientId,
                    EmployeeId = x.EmployeeId,
                    Time = x.Time,
                    Status = x.Status

                }).ToArray();
            return admission;
        }
    }
}
