using Piramida.Storage.Database;
using Piramida.Storage.Models;

namespace Piramid.Logic.Interfaces.Repositories
{
    public interface ISaleRepository
    {
        Sale Create(DataContext dataContext, Sale sale);

        Sale Update(DataContext dataContext, Sale sale);

        void Delete(DataContext dataContext, Guid isnNode);

        Sale GetByID(DataContext dataContext, Guid isnNode);
    }
}
