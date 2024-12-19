using Piramida.Storage.Database;
using Piramida.Storage.Models;

namespace Piramid.Logic.Interfaces.Repositories
{
    public interface IClientRepository
    {
        Client Create(DataContext dataContext, Client client);

        Client Update(DataContext dataContext, Client client);

        void Delete(DataContext dataContext, Guid IsnNode);

        Client GetByID(DataContext dataContext, Guid IsnNode);

    }
}
