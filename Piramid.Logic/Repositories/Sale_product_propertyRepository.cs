using Microsoft.EntityFrameworkCore;
using Piramid.Logic.Interfaces.Repositories;
using Piramida.Storage.Database;
using Piramida.Storage.Models;

namespace Piramid.Logic.Repositories
{
    public class Sale_product_propertyRepository : ISale_product_propertyRepository
    {
        public Sale_product_property Create(DataContext dataContext, Sale_product_property sale_product_property)
        {
            dataContext.Sale_Product_Properties.Add(sale_product_property);
            return sale_product_property;
        }

        public Sale_product_property Update(DataContext dataContext, Sale_product_property sale_product_property)
        {
            var sale_product_propertyDB = dataContext.Sale_Product_Properties.FirstOrDefault(x => x.Id == sale_product_property.Id)
                ?? throw new Exception($"Клиент с данным идентификатором {sale_product_property.Id} не найден");

            sale_product_propertyDB.SaleId = sale_product_property.SaleId;
            sale_product_propertyDB.PropertyId = sale_product_property.PropertyId;
            sale_product_propertyDB.Id = sale_product_property.Id;

            return sale_product_propertyDB;
        }

        public void Delete(DataContext dataContext, Guid id)
        {
            var sale_product_propertyDB = dataContext.Sale_Product_Properties.FirstOrDefault(x => x.Id == id)
                ?? throw new Exception($"Клиент с данным идентификатором {id} не найден");

            dataContext.Sale_Product_Properties.Remove(sale_product_propertyDB);
        }

        public Sale_product_property GetByID(DataContext dataContext, Guid id)
        {
            var sale_product_propertyDB = dataContext.Sale_Product_Properties.AsNoTracking().FirstOrDefault(x => x.Id == id)
                ?? throw new Exception($"Клиент с данным идентификатором {id} не найден");

            // AsNoTracking используется для экономии ресурсов, поскольку такие изменения не отслеживаются.
            return sale_product_propertyDB;
        }
    }
}
