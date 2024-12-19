using Piramida.Logic.DtoModels.Filters;
using Piramida_web.Features.DtoModels.Season_ticket;

namespace Piramida_web.Features.Interface
{
    public interface ISeason_ticketManager
    {
        public void Creat(EditSeason_ticketDto editSeason_ticket);
        public void Update(EditSeason_ticketDto editSeason_ticket);
        public void Delete(Guid Id);
        public Season_ticketDto GetSeason_ticket(Guid Id);
        public Season_ticketDto[] GetListSeason_ticket(Season_ticketFilterDto season_ticketFilter);
    }
}
