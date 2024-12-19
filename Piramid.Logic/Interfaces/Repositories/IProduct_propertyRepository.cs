using Piramida.Storage.Database;
using Piramida.Storage.Models;

namespace Piramid.Logic.Interfaces.Repositories
{
    public interface IProduct_propertyRepository
    {
        Product_property Create(DataContext dataContext, Product_property productProperty);
        Product_property Update(DataContext dataContext, Product_property productProperty);
        void Delete(DataContext dataContext, Guid isnNode);

        Product_property GetByID(DataContext dataContext, Guid isnNode);
    }
}
