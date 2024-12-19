using AutoMapper;
using Piramid.Logic.Interfaces.Repositories;
using Piramid.Logic.Interfaces.Services;
using Piramida.Logic.DtoModels.Filters;
using Piramida.Storage.Database;
using Piramida.Storage.Models;
using Piramida_web.Features.DtoModels.Sale_product_property;
using Piramida_web.Features.Interface;

namespace Piramida_web.Features.Managers
{
    public class Sale_product_propertyManager : ISale_product_propertyManager
    {
        private readonly IMapper _mapper;
        private readonly ISale_product_propertyRepository _saleRepository;
        private readonly ISale_product_propertyService _saleServices;
        private readonly DataContext _dataContext;

        public Sale_product_propertyManager(ISale_product_propertyRepository saleRepository, ISale_product_propertyService saleServices, DataContext dataContext, IMapper mapper)
        {
            _mapper = mapper;
            _saleRepository = saleRepository;
            _saleServices = saleServices;
            _dataContext = dataContext;
        }

        public void Creat(EditSale_product_propertyDto editSale_product_property)
        {
            var Sale_product_property = _mapper.Map<Sale_product_property>(editSale_product_property);

            //System.Console.WriteLine($"Случайный Guid: {Sale_product_property.Id}");

            _saleRepository.Create(_dataContext, Sale_product_property);

            _dataContext.SaveChanges();

        }

        public void Update(EditSale_product_propertyDto editSale_product_property)
        {
            var Sale_product_property = _mapper.Map<Sale_product_property>(editSale_product_property);

            _saleRepository.Update(_dataContext, Sale_product_property);

            _dataContext.SaveChanges();
        }

        public void Delete(Guid Id)
        {
            _saleRepository.Delete(_dataContext, Id);
            _dataContext.SaveChanges();
        }

        public Sale_product_propertyDto GetSale_product_property(Guid Id)
        {
            var sale = _saleRepository.GetByID(_dataContext, Id);
            return _mapper.Map<Sale_product_propertyDto>(sale);
        }

        public Sale_product_propertyDto[] GetListSale_product_property(Sale_product_propertyFilterDto saleFilter)
        {
            var sale = _saleServices.GetSale_product_propertyQueryable(_dataContext, saleFilter, true)
                .Select(x => new Sale_product_propertyDto
                {
                    Id = x.Id,
                    SaleId = x.SaleId,
                    PropertyId = x.PropertyId,

                }).ToArray();
            return sale;
        }

        public Sale_product_propertyDto[] GetListSale_product_propertyBySale(SaleFilterDto saleFilter)
        {
            var sale = _saleServices.GetSale_product_propertyBySaleQueryable(_dataContext, saleFilter, true)
                .Select(x => new Sale_product_propertyDto
                {
                    Id = x.Id,
                    SaleId = x.SaleId,
                    PropertyId = x.PropertyId,

                }).ToArray();
            return sale;
        }
    }
}
