using AutoMapper;
using Piramida.Storage.Models;
using Piramida_web.Features.DtoModels.Cart;

namespace Piramida_web.Features.Mappers
{
    public class CartMapper : Profile
    {
        public CartMapper()
        {
            CreateMap<CartDto, Cart>();
            CreateMap<Cart, CartDto>();

            CreateMap<CartDto[], Cart[]>();
            CreateMap<Cart[], CartDto[]>();

            CreateMap<EditCartDto, Cart>();
            CreateMap<Cart, EditCartDto>();
        }
    }
}
