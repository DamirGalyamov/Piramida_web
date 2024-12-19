using AutoMapper;
using Piramida.Storage.Models;
using Piramida_web.Features.DtoModels.Cart_product;

namespace Piramida_web.Features.Mappers
{
    public class Cart_productMapper : Profile
    {
        public Cart_productMapper()
        {
            CreateMap<Cart_productDto, Cart_product>();
            CreateMap<Cart_product, Cart_productDto>();

            CreateMap<Cart_productDto[], Cart_product[]>();
            CreateMap<Cart_product[], Cart_productDto[]>();

            CreateMap<EditCart_productDto, Cart_product>();
            CreateMap<Cart_product, EditCart_productDto>();

            CreateMap<EditCart_productDto, Cart_productDto>();
            CreateMap<Cart_productDto, EditCart_productDto>();
        }
    }
}
