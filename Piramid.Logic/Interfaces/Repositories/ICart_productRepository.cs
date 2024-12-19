using Piramida.Storage.Database;
using Piramida.Storage.Models;

namespace Piramid.Logic.Interfaces.Repositories
{
    public interface ICart_productRepository
    {
        Cart_product Create(DataContext dataContext, Cart_product cart_product);

        Cart_product Update(DataContext dataContext, Cart_product cart_product);

        void Delete(DataContext dataContext, Guid Id);

        Cart_product GetByID(DataContext dataContext, Guid Id);
    }
}
