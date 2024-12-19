using AutoMapper;
using Piramida.Storage.Models;
using Piramida_web.Features.DtoModels.Cart_additional_property;

namespace Piramida_web.Features.Mappers
{
    public class Cart_additional_propertyMapper : Profile
    {
        public Cart_additional_propertyMapper()
        {
            CreateMap<Cart_additional_propertyDto, Cart_additional_property>();
            CreateMap<Cart_additional_property, Cart_additional_propertyDto>();

            CreateMap<Cart_additional_propertyDto[], Cart_additional_property[]>();
            CreateMap<Cart_additional_property[], Cart_additional_propertyDto[]>();

            CreateMap<EditCart_additional_propertyDto, Cart_additional_property>();
            CreateMap<Cart_additional_property, EditCart_additional_propertyDto>();
        }
    }
}
