using AutoMapper;
using Piramida.Storage.Models;
using Piramida_web.Features.DtoModels.Cart_additional_admission;

namespace Piramida_web.Features.Mappers
{
    public class Cart_additional_admissionMapper : Profile
    {
        public Cart_additional_admissionMapper()
        {
            CreateMap<Cart_additional_admissionDto, Cart_additional_admission>();
            CreateMap<Cart_additional_admission, Cart_additional_admissionDto>();

            CreateMap<Cart_additional_admissionDto[], Cart_additional_admission[]>();
            CreateMap<Cart_additional_admission[], Cart_additional_admissionDto[]>();

            CreateMap<EditCart_additional_admissionDto, Cart_additional_admission>();
            CreateMap<Cart_additional_admission, EditCart_additional_admissionDto>();
        }
    }
}
