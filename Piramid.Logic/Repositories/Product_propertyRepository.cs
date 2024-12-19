using Microsoft.EntityFrameworkCore;
using Piramid.Logic.Interfaces.Repositories;
using Piramida.Storage.Database;
using Piramida.Storage.Models;

namespace Piramid.Logic.Repositories
{
    public class Product_propertyRepository : IProduct_propertyRepository
    {
        public Product_property Create(DataContext dataContext, Product_property productProperty)
        {
            dataContext.Product_properties.Add(productProperty);
            return productProperty;
        }

        public Product_property Update(DataContext dataContext, Product_property productProperty)
        {
            var productPropertyDB = dataContext.Product_properties.FirstOrDefault(x => x.Id == productProperty.Id)
                ?? throw new Exception($"Свойство продукта с данным идентификатором {productProperty.Id} не найдено");

            productPropertyDB.ProductId = productProperty.ProductId;
            productPropertyDB.Id = productProperty.Id;
            productPropertyDB.Price = productProperty.Price;
            productPropertyDB.Name_of_property = productProperty.Name_of_property;
            productPropertyDB.Description_of_property = productProperty.Description_of_property;

            return productPropertyDB;
        }

        public void Delete(DataContext dataContext, Guid id)
        {
            var productPropertyDB = dataContext.Product_properties.FirstOrDefault(x => x.Id == id)
                ?? throw new Exception($"Свойство продукта с данным идентификатором {id} не найдено");

            dataContext.Product_properties.Remove(productPropertyDB);
        }

        public Product_property GetByID(DataContext dataContext, Guid id)
        {
            var productPropertyDB = dataContext.Product_properties.AsNoTracking().FirstOrDefault(x => x.Id == id)
                ?? throw new Exception($"Свойство продукта с данным идентификатором {id} не найдено");

            // AsNoTracking используется для экономии ресурсов, поскольку такие изменения не отслеживаются.
            return productPropertyDB;
        }
    }
}
