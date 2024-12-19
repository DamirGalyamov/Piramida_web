using Microsoft.EntityFrameworkCore;
using Piramid.Logic.Interfaces.Services;
using Piramida.Logic.DtoModels.Filters;
using Piramida.Storage.Database;
using Piramida.Storage.Models;

namespace Piramid.Logic.Services
{
    public class Product_propertyService : IProduct_propertyService
    {
        public IQueryable<Product_property> GetProduct_propertyQueryable(DataContext dataContext, Product_propertyFilterDto filter, bool AsNoTraking)
        {
            IQueryable<Product_property> query = dataContext.Product_properties;

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

        public IQueryable<Product_property> GetProduct_propertyByProductQueryable(DataContext dataContext, Product_propertyByProductFilterDto filter, bool AsNoTraking)
        {
            IQueryable<Product_property> query = dataContext.Product_properties;

            if (AsNoTraking)
            {
                query = query.AsNoTracking();
            }
            if (filter != null)
            {
                query = query.Where(x => x.Id == filter.ProductId);
            }
            return query;
        }
    }
}
