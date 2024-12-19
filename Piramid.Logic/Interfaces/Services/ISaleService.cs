using Piramida.Logic.DtoModels.Filters;
using Piramida.Storage.Database;
using Piramida.Storage.Models;

namespace Piramid.Logic.Interfaces.Services
{
    public interface ISaleService
    {
        IQueryable<Sale> GetSaleQueryable(DataContext dataContext, SaleFilterDto filter, bool AsNoTraking);
        public IQueryable<Sale> GetSaleByProductQueryable(DataContext dataContext, SaleFilterDto filter, bool AsNoTraking);
    }
}
