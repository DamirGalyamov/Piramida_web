using AutoMapper;
using Piramid.Logic.Interfaces.Repositories;
using Piramid.Logic.Interfaces.Services;
using Piramida.Logic.DtoModels.Filters;
using Piramida.Storage.Database;
using Piramida.Storage.Models;
using Piramida_web.Features.DtoModels.Sale;
using Piramida_web.Features.Interface;

namespace Piramida_web.Features.Managers
{
    public class SaleManager : ISaleManager
    {
        private readonly IMapper _mapper;
        private readonly ISaleRepository _saleRepository;
        private readonly ISaleService _saleServices;
        private readonly DataContext _dataContext;

        public SaleManager(ISaleRepository saleRepository, ISaleService saleServices, DataContext dataContext, IMapper mapper)
        {
            _mapper = mapper;
            _saleRepository = saleRepository;
            _saleServices = saleServices;
            _dataContext = dataContext;
        }

        public void Creat(EditSaleDto editSale)
        {
            var Sale = _mapper.Map<Sale>(editSale);

            //System.Console.WriteLine($"Случайный Guid: {Sale.Id}");

            _saleRepository.Create(_dataContext, Sale);

            _dataContext.SaveChanges();

        }

        public void Update(EditSaleDto editSale)
        {
            var Sale = _mapper.Map<Sale>(editSale);

            _saleRepository.Update(_dataContext, Sale);

            _dataContext.SaveChanges();
        }

        public void Delete(Guid Id)
        {
            _saleRepository.Delete(_dataContext, Id);
            _dataContext.SaveChanges();
        }

        public SaleDto GetSale(Guid Id)
        {
            var sale = _saleRepository.GetByID(_dataContext, Id);
            return _mapper.Map<SaleDto>(sale);
        }

        public SaleDto[] GetListSale(SaleFilterDto saleFilter)
        {
            var sale = _saleServices.GetSaleQueryable(_dataContext, saleFilter, true)
                .Select(x => new SaleDto
                {
                    Id = x.Id,
                    ProductId = x.ProductId,
                    Sale_procent = x.Sale_procent,
                    Total_price = x.Total_price,

                }).ToArray();
            return sale;
        }

        public SaleDto[] GetListSaleByProduct(SaleFilterDto saleFilter)
        {
            var sale = _saleServices.GetSaleByProductQueryable(_dataContext, saleFilter, true)
                .Select(x => new SaleDto
                {
                    Id = x.Id,
                    ProductId = x.ProductId,
                    Sale_procent = x.Sale_procent,
                    Total_price = x.Total_price,

                }).ToArray();
            return sale;
        }
    }
}
