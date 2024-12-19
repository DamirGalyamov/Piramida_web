using Microsoft.EntityFrameworkCore;
using Piramid.Logic.Interfaces.Repositories;
using Piramida.Storage.Database;
using Piramida.Storage.Models;

namespace Piramid.Logic.Repositories
{
    public class Season_ticketRepository : ISeason_ticketRepository
    {
        public Season_ticket Create(DataContext dataContext, Season_ticket seasonTicket)
        {
            dataContext.Season_tickets.Add(seasonTicket);
            return seasonTicket;
        }

        public Season_ticket Update(DataContext dataContext, Season_ticket seasonTicket)
        {
            var seasonTicketDB = dataContext.Season_tickets.FirstOrDefault(x => x.Id == seasonTicket.Id)
                ?? throw new Exception($"Абонемент с данным идентификатором {seasonTicket.Id} не найден");

            seasonTicketDB.Id = seasonTicket.Id;
            seasonTicketDB.ProductId = seasonTicket.ProductId;
            seasonTicketDB.ClientId = seasonTicket.ClientId;
            seasonTicketDB.Time_of_purchase = seasonTicket.Time_of_purchase;

            return seasonTicketDB;
        }

        public void Delete(DataContext dataContext, Guid id)
        {
            var seasonTicketDB = dataContext.Season_tickets.FirstOrDefault(x => x.Id == id)
                ?? throw new Exception($"Абонемент с данным идентификатором {id} не найден");

            dataContext.Season_tickets.Remove(seasonTicketDB);
        }

        public Season_ticket GetByID(DataContext dataContext, Guid id)
        {
            var seasonTicketDB = dataContext.Season_tickets.AsNoTracking().FirstOrDefault(x => x.Id == id)
                ?? throw new Exception($"Абонемент с данным идентификатором {id} не найден");

            // AsNoTracking используется для экономии ресурсов, поскольку такие изменения не отслеживаются.
            return seasonTicketDB;
        }
    }
}
