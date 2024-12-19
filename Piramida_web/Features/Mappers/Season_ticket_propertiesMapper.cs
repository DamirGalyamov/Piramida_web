using AutoMapper;
using Piramida.Storage.Models;
using Piramida_web.Features.DtoModels.Season_ticket_properties;

namespace Piramida_web.Features.Mappers
{
    public class Season_ticket_propertiesMapper : Profile
    {
        public Season_ticket_propertiesMapper()
        {
            CreateMap<Season_ticket_propertiesDto, Season_ticket_properties>();
            CreateMap<Season_ticket_properties, Season_ticket_propertiesDto>();

            CreateMap<Season_ticket_propertiesDto[], Season_ticket_properties[]>();
            CreateMap<Season_ticket_properties[], Season_ticket_propertiesDto[]>();

            CreateMap<EditSeason_ticket_propertiesDto, Season_ticket_properties>();
            CreateMap<Season_ticket_properties, EditSeason_ticket_propertiesDto>();
        }
    }
}
