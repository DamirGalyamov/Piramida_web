using Piramida.Storage.Database;
using Piramida.Storage.Models;

namespace Piramid.Logic.Interfaces.Repositories
{
    public interface IProductRepository
    {
        Product Create(DataContext dataContext, Product product);

        Product Update(DataContext dataContext, Product product);

        void Delete(DataContext dataContext, Guid isnNode);

        Product GetByID(DataContext dataContext, Guid isnNode);
    }
}
