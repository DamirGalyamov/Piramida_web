using Microsoft.EntityFrameworkCore;
using Piramid.Logic.Interfaces.Services;
using Piramida.Logic.DtoModels.Filters;
using Piramida.Storage.Database;
using Piramida.Storage.Models;

namespace Piramid.Logic.Services
{
    public class ProductService : IProductService
    {
        public IQueryable<Product> GetProductQueryable(DataContext dataContext, ProductFilterDto filter, bool AsNoTraking)
        {
            IQueryable<Product> query = dataContext.Products;

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
    }
}
