using AutoMapper;
using Piramida.Storage.Models;
using Piramida_web.Features.DtoModels.Product_property;

namespace Piramida_web.Features.Mappers
{
    public class Product_propertyMapper : Profile
    {
        public Product_propertyMapper()
        {
            CreateMap<Product_propertyDto, Product_property>();
            CreateMap<Product_property, Product_propertyDto>();

            CreateMap<Product_propertyDto[], Product_property[]>();
            CreateMap<Product_property[], Product_propertyDto[]>();

            CreateMap<EditProduct_propertyDto, Product_property>();
            CreateMap<Product_property, EditProduct_propertyDto>();
        }
    }
}
