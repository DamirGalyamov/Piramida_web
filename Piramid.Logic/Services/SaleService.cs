using Microsoft.EntityFrameworkCore;
using Piramid.Logic.Interfaces.Services;
using Piramida.Logic.DtoModels.Filters;
using Piramida.Storage.Database;
using Piramida.Storage.Models;

namespace Piramid.Logic.Services
{
    public class SaleService : ISaleService
    {
        public IQueryable<Sale> GetSaleQueryable(DataContext dataContext, SaleFilterDto filter, bool AsNoTraking)
        {
            IQueryable<Sale> query = dataContext.Sales;

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

        public IQueryable<Sale> GetSaleByProductQueryable(DataContext dataContext, SaleFilterDto filter, bool AsNoTraking)
        {
            IQueryable<Sale> query = dataContext.Sales;

            if (AsNoTraking)
            {
                query = query.AsNoTracking();
            }
            if (filter != null)
            {
                query = query.Where(x => x.ProductId == filter.Id);
            }
            return query;
        }
    }
}
