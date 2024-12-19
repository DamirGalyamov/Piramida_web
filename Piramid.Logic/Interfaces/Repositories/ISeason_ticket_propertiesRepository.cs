using Piramida.Storage.Database;
using Piramida.Storage.Models;

namespace Piramid.Logic.Interfaces.Repositories
{
    public interface ISeason_ticket_propertiesRepository
    {
        Season_ticket_properties Create(DataContext dataContext, Season_ticket_properties season_ticket_property);
        Season_ticket_properties Update(DataContext dataContext, Season_ticket_properties season_ticket_property);
        void Delete(DataContext dataContext, Guid id);

        Season_ticket_properties GetByID(DataContext dataContext, Guid id);
    }
}
