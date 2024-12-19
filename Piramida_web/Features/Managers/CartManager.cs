using AutoMapper;
using Piramid.Logic.Interfaces.Repositories;
using Piramid.Logic.Interfaces.Services;
using Piramida.Logic.DtoModels.Filters;
using Piramida.Storage.Database;
using Piramida.Storage.Models;
using Piramida_web.Features.DtoModels.Cart;
using Piramida_web.Features.Interface;

namespace Piramida_web.Features.Managers
{
    public class CartManager : ICartManager
    {
        private readonly IMapper _mapper;
        private readonly ICartRepository _cartRepository;
        private readonly ICartService _cartServices;
        private readonly DataContext _dataContext;

        public CartManager(ICartRepository cartRepository, ICartService cartServices, DataContext dataContext, IMapper mapper)
        {
            _mapper = mapper;
            _cartRepository = cartRepository;
            _cartServices = cartServices;
            _dataContext = dataContext;
        }

        public CartDto Creat(EditCartDto editCart)
        {
            var Carts = _mapper.Map<Cart>(editCart);

            //System.Console.WriteLine($"Случайный Guid: {Cart.Id}");

            _cartRepository.Create(_dataContext, Carts);

            _dataContext.SaveChanges();

            return _mapper.Map<CartDto>(Carts);

        }

        public void Update(EditCartDto editCart)
        {
            var Cart = _mapper.Map<Cart>(editCart);

            _cartRepository.Update(_dataContext, Cart);

            _dataContext.SaveChanges();
        }

        public void Delete(Guid Id)
        {
            _cartRepository.Delete(_dataContext, Id);
            _dataContext.SaveChanges();
        }

        public CartDto GetCart(Guid Id)
        {
            var cart = _cartRepository.GetByID(_dataContext, Id);
            return _mapper.Map<CartDto>(cart);
        }

        public CartDto[] GetListCart(CartFilterDto cartFilter)
        {
            var cart = _cartServices.GetCartQueryable(_dataContext, cartFilter, true)
                .Select(x => new CartDto
                {
                    Id = x.Id,
                    ClientId = x.ClientId,
                }).ToArray();
            return cart;
        }

        public CartDto[] GetListCartByClient(CartFilterDto cartFilter)
        {
            var cart = _cartServices.GetCartByClientQueryable(_dataContext, cartFilter, true)
                .Select(x => new CartDto
                {
                    Id = x.Id,
                    ClientId = x.ClientId,
                }).ToArray();
            return cart;
        }
    }
}
