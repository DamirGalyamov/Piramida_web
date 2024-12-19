using Piramida.Logic.DtoModels.Filters;
using Piramida_web.Features.DtoModels.Season_ticket_properties;

namespace Piramida_web.Features.Interface
{
    public interface ISeason_ticket_propertiesManager
    {
        public void Creat(EditSeason_ticket_propertiesDto editSeason_ticket_properties);
        public void Update(EditSeason_ticket_propertiesDto editSeason_ticket_properties);
        public void Delete(Guid Id);
        public Season_ticket_propertiesDto GetSeason_ticket_properties(Guid Id);
        public Season_ticket_propertiesDto[] GetListSeason_ticket_properties(Season_ticket_propertiesFilterDto clientFilter);
    }
}
