using Piramida.Logic.DtoModels.Filters;
using Piramida.Storage.Database;
using Piramida.Storage.Models;

namespace Piramid.Logic.Interfaces.Services
{
    public interface ICartService
    {
        IQueryable<Cart> GetCartQueryable(DataContext dataContext, CartFilterDto filter, bool AsNoTraking);

        IQueryable<Cart> GetCartByClientQueryable(DataContext dataContext, CartFilterDto filter, bool AsNoTraking);
    }
}