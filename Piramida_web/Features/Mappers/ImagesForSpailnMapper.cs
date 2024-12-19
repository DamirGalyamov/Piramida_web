using AutoMapper;
using Piramida.Storage.Models;
using Piramida_web.Features.DtoModels.ImagesForSpailn;

namespace Piramida_web.Features.Mappers
{
    public class ImagesForSpailnMapper : Profile
    {
        public ImagesForSpailnMapper()
        {
            CreateMap<ImagesForSpailnDto, ImagesForSpailn>();
            CreateMap<ImagesForSpailn, ImagesForSpailnDto>();

            CreateMap<ImagesForSpailnDto[], ImagesForSpailn[]>();
            CreateMap<ImagesForSpailn[], ImagesForSpailnDto[]>();

            CreateMap<EditImagesForSpailnDto, ImagesForSpailn>();
            CreateMap<ImagesForSpailn, EditImagesForSpailnDto>();
        }
    }
}
