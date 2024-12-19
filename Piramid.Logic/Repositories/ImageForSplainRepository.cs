using Microsoft.EntityFrameworkCore;
using Piramid.Logic.Interfaces.Repositories;
using Piramida.Storage.Database;
using Piramida.Storage.Models;

namespace Piramid.Logic.Repositories
{
    public class ImageForSplainRepository : IImageForSplainRepository
    {
        public ImagesForSpailn Create(DataContext dataContext, ImagesForSpailn client)
        {
            dataContext.ImagesForSpailns.Add(client);
            return client;
        }

        public ImagesForSpailn Update(DataContext dataContext, ImagesForSpailn client)
        {
            var clientDB = dataContext.ImagesForSpailns.FirstOrDefault(x => x.Id == client.Id)
                ?? throw new Exception($"Клиент с данным идентификатором {client.Id} не найден");

            clientDB.Id = client.Id;
            clientDB.Titel = client.Titel;
            clientDB.Description = client.Description;
            clientDB.ImageUrl = client.ImageUrl;
            clientDB.link = client.link;

            return clientDB;
        }

        public void Delete(DataContext dataContext, Guid id)
        {
            var clientDB = dataContext.ImagesForSpailns.FirstOrDefault(x => x.Id == id)
                ?? throw new Exception($"Клиент с данным идентификатором {id} не найден");

            dataContext.ImagesForSpailns.Remove(clientDB);
        }

        public ImagesForSpailn GetByID(DataContext dataContext, Guid id)
        {
            var clientDB = dataContext.ImagesForSpailns.AsNoTracking().FirstOrDefault(x => x.Id == id)
                ?? throw new Exception($"Клиент с данным идентификатором {id} не найден");

            // AsNoTracking используется для экономии ресурсов, поскольку такие изменения не отслеживаются.
            return clientDB;
        }
    }
}
