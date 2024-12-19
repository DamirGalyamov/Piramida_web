using Piramida.Storage.Database;
using Piramida.Storage.Models;

namespace Piramid.Logic.Interfaces.Repositories
{
    public interface ISale_product_propertyRepository
    {
        Sale_product_property Create(DataContext dataContext, Sale_product_property sale_product_property);

        Sale_product_property Update(DataContext dataContext, Sale_product_property sale_product_property);

        void Delete(DataContext dataContext, Guid Id);

        Sale_product_property GetByID(DataContext dataContext, Guid Id);

    }
}
