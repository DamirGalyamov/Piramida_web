using AutoMapper;
using Piramida.Storage.Models;
using Piramida_web.Features.DtoModels.Product;

namespace Piramida_web.Features.Mappers
{
    public class ProductMapper : Profile
    {
        public ProductMapper()
        {
            CreateMap<ProductDto, Product>();
            CreateMap<Product, ProductDto>();

            CreateMap<ProductDto[], Product[]>();
            CreateMap<Product[], ProductDto[]>();

            CreateMap<EditProductDto, Product>();
            CreateMap<Product, EditProductDto>();
        }
    }
}
