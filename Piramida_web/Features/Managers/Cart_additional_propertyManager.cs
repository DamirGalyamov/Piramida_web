using AutoMapper;
using Piramid.Logic.Interfaces.Repositories;
using Piramid.Logic.Interfaces.Services;
using Piramida.Logic.DtoModels.Filters;
using Piramida.Storage.Database;
using Piramida.Storage.Models;
using Piramida_web.Features.DtoModels.Cart_additional_property;
using Piramida_web.Features.Interface;

namespace Piramida_web.Features.Managers
{
    public class Cart_additional_propertyManager : ICart_additional_propertyManager
    {
        private readonly IMapper _mapper;
        private readonly ICart_additional_propertyRepository _cart_additional_propertyRepository;
        private readonly ICart_additional_propertyService _cart_additional_propertyServices;
        private readonly DataContext _dataContext;

        public Cart_additional_propertyManager(ICart_additional_propertyRepository cart_additional_propertyRepository, ICart_additional_propertyService cart_additional_propertyServices, DataContext dataContext, IMapper mapper)
        {
            _mapper = mapper;
            _cart_additional_propertyRepository = cart_additional_propertyRepository;
            _cart_additional_propertyServices = cart_additional_propertyServices;
            _dataContext = dataContext;
        }

        public void Creat(EditCart_additional_propertyDto editCart_additional_property)
        {
            var Cart_additional_propertys = _mapper.Map<Cart_additional_property>(editCart_additional_property);

            //System.Console.WriteLine($"Случайный Guid: {Cart_additional_property.Id}");

            _cart_additional_propertyRepository.Create(_dataContext, Cart_additional_propertys);

            _dataContext.SaveChanges();

        }

        public void Update(EditCart_additional_propertyDto editCart_additional_property)
        {
            var Cart_additional_property = _mapper.Map<Cart_additional_property>(editCart_additional_property);

            _cart_additional_propertyRepository.Update(_dataContext, Cart_additional_property);

            _dataContext.SaveChanges();
        }

        public void Delete(Guid Id)
        {
            _cart_additional_propertyRepository.Delete(_dataContext, Id);
            _dataContext.SaveChanges();
        }

        public Cart_additional_propertyDto GetCart_additional_property(Guid Id)
        {
            var cart_additional_property = _cart_additional_propertyRepository.GetByID(_dataContext, Id);
            return _mapper.Map<Cart_additional_propertyDto>(cart_additional_property);
        }

        public Cart_additional_propertyDto[] GetListCart_additional_property(Cart_additional_propertyFilterDto cart_additional_propertyFilter)
        {
            var cart_additional_property = _cart_additional_propertyServices.GetCart_additional_propertyQueryable(_dataContext, cart_additional_propertyFilter, true)
                .Select(x => new Cart_additional_propertyDto
                {
                    Id = x.Id,
                    Product_propertyId = x.Product_propertyId,
                    Cart_productId = x.Cart_productId,

                }).ToArray();
            return cart_additional_property;
        }
    }
}
