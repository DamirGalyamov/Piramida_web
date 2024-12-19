using AutoMapper;
using Piramida.Storage.Models;
using Piramida_web.Features.DtoModels.Admission;

namespace Piramida_web.Features.Mappers
{
    public class AdmissionMapper : Profile
    {
        public AdmissionMapper()
        {
            CreateMap<AdmissionDto, Admission>();
            CreateMap<Admission, AdmissionDto>();

            CreateMap<AdmissionDto[], Admission[]>();
            CreateMap<Admission[], AdmissionDto[]>();

            CreateMap<EditAdmissionDto, Admission>();
            CreateMap<Admission, EditAdmissionDto>();
        }
    }
}
