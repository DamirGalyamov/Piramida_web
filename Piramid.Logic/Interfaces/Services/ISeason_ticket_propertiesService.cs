using Piramida.Logic.DtoModels.Filters;
using Piramida.Storage.Database;
using Piramida.Storage.Models;

namespace Piramid.Logic.Interfaces.Services
{
    public interface ISeason_ticket_propertiesService
    {
        IQueryable<Season_ticket_properties> GetSeason_ticket_propertiesQueryable(DataContext dataContext, Season_ticket_propertiesFilterDto filter, bool AsNoTraking);
    }
}