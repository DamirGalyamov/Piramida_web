using AutoMapper;
using Piramida.Storage.Models;
using Piramida_web.Features.DtoModels.Sale;

namespace Piramida_web.Features.Mappers
{
    public class SaleMapper : Profile
    {
        public SaleMapper()
        {
            CreateMap<SaleDto, Sale>();
            CreateMap<Sale, SaleDto>();

            CreateMap<SaleDto[], Sale[]>();
            CreateMap<Sale[], SaleDto[]>();

            CreateMap<EditSaleDto, Sale>();
            CreateMap<Sale, EditSaleDto>();
        }
    }
}
