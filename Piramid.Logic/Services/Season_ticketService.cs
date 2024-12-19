using Microsoft.EntityFrameworkCore;
using Piramid.Logic.Interfaces.Services;
using Piramida.Logic.DtoModels.Filters;
using Piramida.Storage.Database;
using Piramida.Storage.Models;

namespace Piramid.Logic.Services
{
    public class Season_ticketService : ISeason_ticketService
    {
        public IQueryable<Season_ticket> GetSeason_ticketQueryable(DataContext dataContext, Season_ticketFilterDto filter, bool AsNoTraking)
        {
            IQueryable<Season_ticket> query = dataContext.Season_tickets;

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
