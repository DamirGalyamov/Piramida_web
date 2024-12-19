using Piramida.Logic.DtoModels.Filters;
using Piramida.Storage.Database;
using Piramida.Storage.Models;

namespace Piramid.Logic.Interfaces.Services
{
    public interface IProduct_propertyService
    {
        IQueryable<Product_property> GetProduct_propertyQueryable(DataContext dataContext, Product_propertyFilterDto filter, bool AsNoTraking);
        IQueryable<Product_property> GetProduct_propertyByProductQueryable(DataContext dataContext, Product_propertyByProductFilterDto filter, bool AsNoTraking);
    }
}
