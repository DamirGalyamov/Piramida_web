using Microsoft.EntityFrameworkCore;
using Piramid.Logic.Interfaces.Services;
using Piramida.Logic.DtoModels.Filters;
using Piramida.Storage.Database;
using Piramida.Storage.Models;

namespace Piramid.Logic.Services
{
    public class Cart_productService : ICart_productService
    {
        public IQueryable<Cart_product> GetCart_productQueryable(DataContext dataContext, Cart_productFilterDto filter, bool AsNoTraking)
        {
            IQueryable<Cart_product> query = dataContext.Cart_products;

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

        public IQueryable<Cart_product> GetCart_productByCartQueryable(DataContext dataContext, Cart_productFilterDto filter, bool AsNoTraking)
        {
            IQueryable<Cart_product> query = dataContext.Cart_products;

            if (AsNoTraking)
            {
                query = query.AsNoTracking();
            }
            if (filter != null)
            {
                query = query.Where(x => x.CartId == filter.Id);
            }
            return query;
        }
    }
}
