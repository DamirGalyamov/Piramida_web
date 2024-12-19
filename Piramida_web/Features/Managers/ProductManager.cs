using AutoMapper;
using Piramid.Logic.Interfaces.Repositories;
using Piramid.Logic.Interfaces.Services;
using Piramida.Logic.DtoModels.Filters;
using Piramida.Storage.Database;
using Piramida.Storage.Models;
using Piramida_web.Features.DtoModels.Product;
using Piramida_web.Features.Interface;

namespace Piramida_web.Features.Managers
{
    public class ProductManager : IProductManager
    {
        private readonly IMapper _mapper;
        private readonly IProductRepository _productRepository;
        private readonly IProductService _productServices;
        private readonly DataContext _dataContext;

        public ProductManager(IProductRepository productRepository, IProductService productServices, DataContext dataContext, IMapper mapper)
        {
            _mapper = mapper;
            _productRepository = productRepository;
            _productServices = productServices;
            _dataContext = dataContext;
        }

        public void Creat(EditProductDto editProduct)
        {
            var Product = _mapper.Map<Product>(editProduct);

            //System.Console.WriteLine($"Случайный Guid: {Product.Id}");

            _productRepository.Create(_dataContext, Product);

            _dataContext.SaveChanges();

        }

        public void Update(EditProductDto editProduct)
        {
            var Product = _mapper.Map<Product>(editProduct);

            _productRepository.Update(_dataContext, Product);

            _dataContext.SaveChanges();
        }

        public void Delete(Guid Id)
        {
            _productRepository.Delete(_dataContext, Id);
            _dataContext.SaveChanges();
        }

        public ProductDto GetProduct(Guid Id)
        {
            var product = _productRepository.GetByID(_dataContext, Id);
            return _mapper.Map<ProductDto>(product);
        }

        public ProductDto[] GetListProduct(ProductFilterDto productFilter)
        {
            var product = _productServices.GetProductQueryable(_dataContext, productFilter, true)
                .Select(x => new ProductDto
                {
                    Id = x.Id,
                    Name = x.Name,
                    Price = x.Price,
                    Short_description = x.Short_description,
                    Description = x.Description,
                    ImageUrl = x.ImageUrl,
                    Category = x.Category

                }).ToArray();
            return product;
        }
    }
}
