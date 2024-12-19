using Piramida.Storage.Database;
using Piramida.Storage.Models;

namespace Piramid.Logic.Interfaces.Repositories
{
    public interface ICartRepository
    {
        Cart Create(DataContext dataContext, Cart cart);

        Cart Update(DataContext dataContext, Cart cart);

        void Delete(DataContext dataContext, Guid Id);

        Cart GetByID(DataContext dataContext, Guid Id);
    }
}
