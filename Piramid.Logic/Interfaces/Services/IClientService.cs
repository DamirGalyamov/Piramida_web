using Piramida.Logic.DtoModels.Filters;
using Piramida.Storage.Database;
using Piramida.Storage.Models;

namespace Piramid.Logic.Interfaces.Services
{
    public interface IClientService
    {
        IQueryable<Client> GetClientQueryable(DataContext dataContext, ClientFilterDto filter, bool AsNoTraking);
    }
}
