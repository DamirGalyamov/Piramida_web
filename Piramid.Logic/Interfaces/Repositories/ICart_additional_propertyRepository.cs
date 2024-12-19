using Piramida.Storage.Database;
using Piramida.Storage.Models;

namespace Piramid.Logic.Interfaces.Repositories
{
    public interface ICart_additional_propertyRepository
    {
        Cart_additional_property Create(DataContext dataContext, Cart_additional_property cart_additional_property);

        Cart_additional_property Update(DataContext dataContext, Cart_additional_property cart_additional_property);

        void Delete(DataContext dataContext, Guid Id);

        Cart_additional_property GetByID(DataContext dataContext, Guid Id);
    }
}
