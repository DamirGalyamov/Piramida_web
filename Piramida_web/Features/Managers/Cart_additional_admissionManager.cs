using AutoMapper;
using Piramid.Logic.Interfaces.Repositories;
using Piramid.Logic.Interfaces.Services;
using Piramida.Logic.DtoModels.Filters;
using Piramida.Storage.Database;
using Piramida.Storage.Models;
using Piramida_web.Features.DtoModels.Cart_additional_admission;
using Piramida_web.Features.Interface;

namespace Piramida_web.Features.Managers
{
    public class Cart_additional_admissionManager : ICart_additional_admissionManager
    {
        private readonly IMapper _mapper;
        private readonly ICart_additional_admissionRepository _cart_additional_admissionRepository;
        private readonly ICart_additional_admissionService _cart_additional_admissionServices;
        private readonly DataContext _dataContext;

        public Cart_additional_admissionManager(ICart_additional_admissionRepository cart_additional_admissionRepository, ICart_additional_admissionService cart_additional_admissionServices, DataContext dataContext, IMapper mapper)
        {
            _mapper = mapper;
            _cart_additional_admissionRepository = cart_additional_admissionRepository;
            _cart_additional_admissionServices = cart_additional_admissionServices;
            _dataContext = dataContext;
        }

        public void Creat(EditCart_additional_admissionDto editCart_additional_admission)
        {
            var Cart_additional_admissions = _mapper.Map<Cart_additional_admission>(editCart_additional_admission);

            //System.Console.WriteLine($"Случайный Guid: {Cart_additional_admission.Id}");

            _cart_additional_admissionRepository.Create(_dataContext, Cart_additional_admissions);

            _dataContext.SaveChanges();

        }

        public void Update(EditCart_additional_admissionDto editCart_additional_admission)
        {
            var Cart_additional_admission = _mapper.Map<Cart_additional_admission>(editCart_additional_admission);

            _cart_additional_admissionRepository.Update(_dataContext, Cart_additional_admission);

            _dataContext.SaveChanges();
        }

        public void Delete(Guid Id)
        {
            _cart_additional_admissionRepository.Delete(_dataContext, Id);
            _dataContext.SaveChanges();
        }

        public Cart_additional_admissionDto GetCart_additional_admission(Guid Id)
        {
            var cart_additional_admission = _cart_additional_admissionRepository.GetByID(_dataContext, Id);
            return _mapper.Map<Cart_additional_admissionDto>(cart_additional_admission);
        }

        public Cart_additional_admissionDto[] GetListCart_additional_admission(Cart_additional_admissionFilterDto cart_additional_admissionFilter)
        {
            var cart_additional_admission = _cart_additional_admissionServices.GetCart_additional_admissionQueryable(_dataContext, cart_additional_admissionFilter, true)
                .Select(x => new Cart_additional_admissionDto
                {
                    Id = x.Id,
                    Cart_productId = x.Cart_productId,
                    AdmissionId = x.AdmissionId,

                }).ToArray();
            return cart_additional_admission;
        }
    }
}
