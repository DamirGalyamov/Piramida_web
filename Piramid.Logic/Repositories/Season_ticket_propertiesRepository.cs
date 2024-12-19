using Microsoft.EntityFrameworkCore;
using Piramid.Logic.Interfaces.Repositories;
using Piramida.Storage.Database;
using Piramida.Storage.Models;

namespace Piramid.Logic.Repositories
{
    public class Season_ticket_propertiesRepository : ISeason_ticket_propertiesRepository
    {
        public Season_ticket_properties Create(DataContext dataContext, Season_ticket_properties season_ticket_properties)
        {
            dataContext.Season_Ticket_Properties.Add(season_ticket_properties);
            return season_ticket_properties;
        }

        public Season_ticket_properties Update(DataContext dataContext, Season_ticket_properties season_ticket_properties)
        {
            var season_ticket_propertiesDB = dataContext.Season_Ticket_Properties.FirstOrDefault(x => x.Id == season_ticket_properties.Id)
                ?? throw new Exception($"Абонемент с данным идентификатором {season_ticket_properties.Id} не найден");

            season_ticket_propertiesDB.Id = season_ticket_properties.Id;
            season_ticket_propertiesDB.Season_ticketId = season_ticket_properties.Season_ticketId;
            season_ticket_propertiesDB.Product_propertyId = season_ticket_properties.Product_propertyId;

            return season_ticket_propertiesDB;
        }

        public void Delete(DataContext dataContext, Guid id)
        {
            var season_ticket_propertiesDB = dataContext.Season_Ticket_Properties.FirstOrDefault(x => x.Id == id)
                ?? throw new Exception($"Абонемент с данным идентификатором {id} не найден");

            dataContext.Season_Ticket_Properties.Remove(season_ticket_propertiesDB);
        }

        public Season_ticket_properties GetByID(DataContext dataContext, Guid id)
        {
            var season_ticket_propertiesDB = dataContext.Season_Ticket_Properties.AsNoTracking().FirstOrDefault(x => x.Id == id)
                ?? throw new Exception($"Абонемент с данным идентификатором {id} не найден");

            // AsNoTracking используется для экономии ресурсов, поскольку такие изменения не отслеживаются.
            return season_ticket_propertiesDB;
        }
    }
}
