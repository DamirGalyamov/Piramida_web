using AutoMapper;
using Piramid.Logic.Interfaces.Repositories;
using Piramid.Logic.Interfaces.Services;
using Piramida.Logic.DtoModels.Filters;
using Piramida.Storage.Database;
using Piramida.Storage.Models;
using Piramida_web.Features.DtoModels.Product_property;
using Piramida_web.Features.Interface;

namespace Piramida_web.Features.Managers
{
    public class Product_propertyManager : IProduct_propertyManager
    {
        private readonly IMapper _mapper;
        private readonly IProduct_propertyRepository _product_propertyRepository;
        private readonly IProduct_propertyService _product_propertyServices;
        private readonly DataContext _dataContext;

        public Product_propertyManager(IProduct_propertyRepository product_propertyRepository, IProduct_propertyService product_propertyServices, DataContext dataContext, IMapper mapper)
        {
            _mapper = mapper;
            _product_propertyRepository = product_propertyRepository;
            _product_propertyServices = product_propertyServices;
            _dataContext = dataContext;
        }

        public void Creat(EditProduct_propertyDto editProduct_property)
        {
            var Product_property = _mapper.Map<Product_property>(editProduct_property);

            //System.Console.WriteLine($"Случайный Guid: {Product_property.Id}");

            _product_propertyRepository.Create(_dataContext, Product_property);

            _dataContext.SaveChanges();

        }

        public void Update(EditProduct_propertyDto editProduct_property)
        {
            var Product_property = _mapper.Map<Product_property>(editProduct_property);

            _product_propertyRepository.Update(_dataContext, Product_property);

            _dataContext.SaveChanges();
        }

        public void Delete(Guid Id)
        {
            _product_propertyRepository.Delete(_dataContext, Id);
            _dataContext.SaveChanges();
        }

        public Product_propertyDto GetProduct_property(Guid Id)
        {
            var product_property = _product_propertyRepository.GetByID(_dataContext, Id);
            return _mapper.Map<Product_propertyDto>(product_property);
        }

        public Product_propertyDto[] GetListProduct_property(Product_propertyFilterDto product_propertyFilter)
        {
            var product_property = _product_propertyServices.GetProduct_propertyQueryable(_dataContext, product_propertyFilter, true)
                .Select(x => new Product_propertyDto
                {
                    Id = x.Id,
                    ProductId = x.ProductId,
                    Price = x.Price,
                    Description_of_property = x.Description_of_property,
                    Name_of_property = x.Name_of_property,

                }).ToArray();
            return product_property;
        }

        public Product_propertyDto[] GetListProduct_propertyByProduct(Product_propertyByProductFilterDto product_propertyByProduct)
        {
            var product_property = _product_propertyServices.GetProduct_propertyByProductQueryable(_dataContext, product_propertyByProduct, true)
                .Select(x => new Product_propertyDto
                {
                    Id = x.Id,
                    ProductId = x.ProductId,
                    Price = x.Price,
                    Description_of_property = x.Description_of_property,
                    Name_of_property = x.Name_of_property,

                }).ToArray();
            return product_property;
        }
    }
}
