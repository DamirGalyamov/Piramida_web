using Microsoft.EntityFrameworkCore;
using Piramid.Logic.Interfaces.Repositories;
using Piramida.Storage.Database;
using Piramida.Storage.Models;

namespace Piramid.Logic.Repositories
{
    public class ClientRepository : IClientRepository
    {
        public Client Create(DataContext dataContext, Client client)
        {
            dataContext.Clients.Add(client);
            return client;
        }

        public Client Update(DataContext dataContext, Client client)
        {
            var clientDB = dataContext.Clients.FirstOrDefault(x => x.Id == client.Id)
                ?? throw new Exception($"Клиент с данным идентификатором {client.Id} не найден");

            clientDB.Id = client.Id;
            clientDB.Name = client.Name;
            clientDB.Telephone = client.Telephone;
            clientDB.Login = client.Login;
            clientDB.Email = client.Email;
            clientDB.Password = client.Password;

            return clientDB;
        }

        public void Delete(DataContext dataContext, Guid id)
        {
            var clientDB = dataContext.Clients.FirstOrDefault(x => x.Id == id)
                ?? throw new Exception($"Клиент с данным идентификатором {id} не найден");

            dataContext.Clients.Remove(clientDB);
        }

        public Client GetByID(DataContext dataContext, Guid id)
        {
            var clientDB = dataContext.Clients.AsNoTracking().FirstOrDefault(x => x.Id == id)
                ?? throw new Exception($"Клиент с данным идентификатором {id} не найден");

            // AsNoTracking используется для экономии ресурсов, поскольку такие изменения не отслеживаются.
            return clientDB;
        }
    }
}
