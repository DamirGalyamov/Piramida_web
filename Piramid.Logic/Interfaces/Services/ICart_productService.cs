using Piramida.Logic.DtoModels.Filters;
using Piramida.Storage.Database;
using Piramida.Storage.Models;

namespace Piramid.Logic.Interfaces.Services
{
    public interface ICart_productService
    {
        IQueryable<Cart_product> GetCart_productQueryable(DataContext dataContext, Cart_productFilterDto filter, bool AsNoTraking);
        public IQueryable<Cart_product> GetCart_productByCartQueryable(DataContext dataContext, Cart_productFilterDto filter, bool AsNoTraking);
    }
}