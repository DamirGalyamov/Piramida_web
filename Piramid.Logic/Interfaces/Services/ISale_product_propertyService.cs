using Piramida.Logic.DtoModels.Filters;
using Piramida.Storage.Database;
using Piramida.Storage.Models;

namespace Piramid.Logic.Interfaces.Services
{
    public interface ISale_product_propertyService
    {
        IQueryable<Sale_product_property> GetSale_product_propertyQueryable(DataContext dataContext, Sale_product_propertyFilterDto filter, bool AsNoTraking);
        public IQueryable<Sale_product_property> GetSale_product_propertyBySaleQueryable(DataContext dataContext, SaleFilterDto filter, bool AsNoTraking);
    }
}