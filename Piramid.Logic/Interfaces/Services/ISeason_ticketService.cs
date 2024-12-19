using Piramida.Logic.DtoModels.Filters;
using Piramida.Storage.Database;
using Piramida.Storage.Models;

namespace Piramid.Logic.Interfaces.Services
{
    public interface ISeason_ticketService
    {
        IQueryable<Season_ticket> GetSeason_ticketQueryable(DataContext dataContext, Season_ticketFilterDto filter, bool AsNoTraking);
    }
}
