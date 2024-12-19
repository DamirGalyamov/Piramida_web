using Microsoft.EntityFrameworkCore;
using Piramid.Logic.Interfaces.Services;
using Piramida.Logic.DtoModels.Filters;
using Piramida.Storage.Database;
using Piramida.Storage.Models;

namespace Piramid.Logic.Services
{
    public class Season_ticket_propertiesService : ISeason_ticket_propertiesService
    {
        public IQueryable<Season_ticket_properties> GetSeason_ticket_propertiesQueryable(DataContext dataContext, Season_ticket_propertiesFilterDto filter, bool AsNoTraking)
        {
            IQueryable<Season_ticket_properties> query = dataContext.Season_Ticket_Properties;

            if (AsNoTraking)
            {
                query = query.AsNoTracking();
            }
            if (filter != null)
            {
                query = query.Where(x => x.Id == filter.Id);
            }
            return query;
        }
    }
}
