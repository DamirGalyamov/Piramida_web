using Microsoft.EntityFrameworkCore;
using Piramid.Logic.Interfaces.Repositories;
using Piramida.Storage.Database;
using Piramida.Storage.Models;

namespace Piramid.Logic.Repositories
{
    public class ProductRepository : IProductRepository
    {
        public Product Create(DataContext dataContext, Product product)
        {
            dataContext.Products.Add(product);
            return product;
        }

        public Product Update(DataContext dataContext, Product product)
        {
            var productDB = dataContext.Products.FirstOrDefault(x => x.Id == product.Id)
                ?? throw new Exception($"Продукт с данным идентификатором {product.Id} не найден");

            productDB.Name = product.Name;
            productDB.Price = product.Price;
            productDB.Short_description = product.Short_description;
            productDB.Description = product.Description;
            productDB.ImageUrl = product.ImageUrl;

            return productDB;
        }

        public void Delete(DataContext dataContext, Guid id)
        {
            var productDB = dataContext.Products.FirstOrDefault(x => x.Id == id)
                ?? throw new Exception($"Продукт с данным идентификатором {id} не найден");

            dataContext.Products.Remove(productDB);
        }

        public Product GetByID(DataContext dataContext, Guid id)
        {
            var productDB = dataContext.Products.AsNoTracking().FirstOrDefault(x => x.Id == id)
                ?? throw new Exception($"Продукт с данным идентификатором {id} не найден");

            // AsNoTracking используется для экономии ресурсов, поскольку такие изменения не отслеживаются.
            return productDB;
        }
    }
}
