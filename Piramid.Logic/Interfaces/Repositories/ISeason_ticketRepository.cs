using Piramida.Storage.Database;
using Piramida.Storage.Models;

namespace Piramid.Logic.Interfaces.Repositories
{
    public interface ISeason_ticketRepository
    {
        Season_ticket Create(DataContext dataContext, Season_ticket season_ticket);
        Season_ticket Update(DataContext dataContext, Season_ticket season_ticket);
        void Delete(DataContext dataContext, Guid isnNode);

        Season_ticket GetByID(DataContext dataContext, Guid isnNode);
    }
}
