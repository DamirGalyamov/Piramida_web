using Piramida.Logic.DtoModels.Filters;
using Piramida.Storage.Database;
using Piramida.Storage.Models;

namespace Piramid.Logic.Interfaces.Services
{
    public interface IProductService
    {
        IQueryable<Product> GetProductQueryable(DataContext dataContext, ProductFilterDto filter, bool AsNoTraking);
    }
}
