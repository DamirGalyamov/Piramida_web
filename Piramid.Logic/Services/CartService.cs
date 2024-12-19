using Microsoft.EntityFrameworkCore;
using Piramid.Logic.Interfaces.Services;
using Piramida.Logic.DtoModels.Filters;
using Piramida.Storage.Database;
using Piramida.Storage.Models;

namespace Piramid.Logic.Services
{
    public class CartService : ICartService
    {
        public IQueryable<Cart> GetCartQueryable(DataContext dataContext, CartFilterDto filter, bool AsNoTraking)
        {
            IQueryable<Cart> query = dataContext.Carts;

            if (AsNoTraking)
            {
                query = query.AsNoTracking();
            }
            if (filter != null)
            {
                query = query.Where(x => x.Id == filter.Id);
            }
            return query;
        }

        public IQueryable<Cart> GetCartByClientQueryable(DataContext dataContext, CartFilterDto filter, bool AsNoTraking)
        {
            IQueryable<Cart> query = dataContext.Carts;

            if (AsNoTraking)
            {
                query = query.AsNoTracking();
            }
            if (filter != null)
            {
                query = query.Where(x => x.ClientId == filter.Id);
            }
            return query;
        }
    }
}
