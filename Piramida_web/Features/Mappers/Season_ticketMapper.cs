using AutoMapper;
using Piramida.Storage.Models;
using Piramida_web.Features.DtoModels.Season_ticket;

namespace Piramida_web.Features.Mappers
{
    public class Season_ticketMapper : Profile
    {
        public Season_ticketMapper()
        {
            CreateMap<Season_ticketDto, Season_ticket>();
            CreateMap<Season_ticket, Season_ticketDto>();

            CreateMap<Season_ticketDto[], Season_ticket[]>();
            CreateMap<Season_ticket[], Season_ticketDto[]>();

            CreateMap<EditSeason_ticketDto, Season_ticket>();
            CreateMap<Season_ticket, EditSeason_ticketDto>();
        }
    }
}
