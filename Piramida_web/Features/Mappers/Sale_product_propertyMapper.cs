using AutoMapper;
using Piramida.Storage.Models;
using Piramida_web.Features.DtoModels.Sale_product_property;

namespace Piramida_web.Features.Mappers
{
    public class Sale_product_propertyMapper : Profile
    {
        public Sale_product_propertyMapper()
        {
            CreateMap<Sale_product_propertyDto, Sale_product_property>();
            CreateMap<Sale_product_property, Sale_product_propertyDto>();

            CreateMap<Sale_product_propertyDto[], Sale_product_property[]>();
            CreateMap<Sale_product_property[], Sale_product_propertyDto[]>();

            CreateMap<EditSale_product_propertyDto, Sale_product_property>();
            CreateMap<Sale_product_property, EditSale_product_propertyDto>();
        }
    }
}
