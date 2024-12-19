using Microsoft.EntityFrameworkCore;
using Piramid.Logic.Interfaces.Repositories;
using Piramida.Storage.Database;
using Piramida.Storage.Models;

namespace Piramid.Logic.Repositories
{
    public class SaleRepository : ISaleRepository
    {
        public Sale Create(DataContext dataContext, Sale sale)
        {
            dataContext.Sales.Add(sale);
            return sale;
        }

        public Sale Update(DataContext dataContext, Sale sale)
        {
            var saleDB = dataContext.Sales.FirstOrDefault(x => x.Id == sale.Id)
                ?? throw new Exception($"Скидка с данным идентификатором {sale.Id} не найдена");

            saleDB.Id = sale.Id;
            saleDB.ProductId = sale.ProductId;
            saleDB.Sale_procent = sale.Sale_procent;
            saleDB.Total_price = sale.Total_price;

            return saleDB;
        }

        public void Delete(DataContext dataContext, Guid id)
        {
            var saleDB = dataContext.Sales.FirstOrDefault(x => x.Id == id)
                ?? throw new Exception($"Скидка с данным идентификатором {id} не найдена");

            dataContext.Sales.Remove(saleDB);
        }

        public Sale GetByID(DataContext dataContext, Guid id)
        {
            var saleDB = dataContext.Sales.AsNoTracking().FirstOrDefault(x => x.Id == id)
                ?? throw new Exception($"Скидка с данным идентификатором {id} не найдена");

            // AsNoTracking используется для экономии ресурсов, поскольку такие изменения не отслеживаются.
            return saleDB;
        }
    }
}
