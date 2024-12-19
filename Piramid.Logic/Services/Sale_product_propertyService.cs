using Microsoft.EntityFrameworkCore;
using Piramid.Logic.Interfaces.Services;
using Piramida.Logic.DtoModels.Filters;
using Piramida.Storage.Database;
using Piramida.Storage.Models;

namespace Piramid.Logic.Services
{
    public class Sale_product_propertyService : ISale_product_propertyService
    {
        public IQueryable<Sale_product_property> GetSale_product_propertyQueryable(DataContext dataContext, Sale_product_propertyFilterDto filter, bool AsNoTraking)
        {
            IQueryable<Sale_product_property> query = dataContext.Sale_Product_Properties;

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
        public IQueryable<Sale_product_property> GetSale_product_propertyBySaleQueryable(DataContext dataContext, SaleFilterDto filter, bool AsNoTraking)
        {
            IQueryable<Sale_product_property> query = dataContext.Sale_Product_Properties;

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
