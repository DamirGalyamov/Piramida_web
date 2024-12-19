using AutoMapper;
using Piramid.Logic.Interfaces.Repositories;
using Piramid.Logic.Interfaces.Services;
using Piramida.Logic.DtoModels.Filters;
using Piramida.Storage.Database;
using Piramida.Storage.Models;
using Piramida_web.Features.DtoModels.Cart_product;
using Piramida_web.Features.Interface;

namespace Piramida_web.Features.Managers
{
    public class Cart_productManager : ICart_productManager
    {
        private readonly IMapper _mapper;
        private readonly ICart_productRepository _cart_productRepository;
        private readonly ICart_productService _cart_productServices;
        private readonly DataContext _dataContext;

        public Cart_productManager(ICart_productRepository cart_productRepository, ICart_productService cart_productServices, DataContext dataContext, IMapper mapper)
        {
            _mapper = mapper;
            _cart_productRepository = cart_productRepository;
            _cart_productServices = cart_productServices;
            _dataContext = dataContext;
        }

        public void Creat(EditCart_productDto editCart_product)
        {
            var Cart_products = _mapper.Map<Cart_product>(editCart_product);

            //System.Console.WriteLine($"Случайный Guid: {Cart_product.Id}");

            _cart_productRepository.Create(_dataContext, Cart_products);

            _dataContext.SaveChanges();

        }

        public void Update(EditCart_productDto editCart_product)
        {
            var Cart_product = _mapper.Map<Cart_product>(editCart_product);

            _cart_productRepository.Update(_dataContext, Cart_product);

            _dataContext.SaveChanges();
        }

        public void Delete(Guid Id)
        {
            _cart_productRepository.Delete(_dataContext, Id);
            _dataContext.SaveChanges();
        }

        public Cart_productDto GetCart_product(Guid Id)
        {
            var cart_product = _cart_productRepository.GetByID(_dataContext, Id);
            return _mapper.Map<Cart_productDto>(cart_product);
        }

        public Cart_productDto[] GetListCart_product(Cart_productFilterDto cart_productFilter)
        {
            var cart_product = _cart_productServices.GetCart_productQueryable(_dataContext, cart_productFilter, true)
                .Select(x => new Cart_productDto
                {
                    Id = x.Id,
                    ProductId = x.ProductId,
                    CartId = x.CartId,
                    count = x.count,

                }).ToArray();
            return cart_product;
        }
        public Cart_productDto[] GetListCart_productByCart(Cart_productFilterDto cart_productFilter)
        {
            var cart_product = _cart_productServices.GetCart_productByCartQueryable(_dataContext, cart_productFilter, true)
                .Select(x => new Cart_productDto
                {
                    Id = x.Id,
                    ProductId = x.ProductId,
                    CartId = x.CartId,
                    count = x.count,

                }).ToArray();
            return cart_product;
        }
    }
}
