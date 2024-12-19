using Microsoft.EntityFrameworkCore;
using Piramid.Logic.Interfaces.Repositories;
using Piramida.Storage.Database;
using Piramida.Storage.Models;

namespace Piramid.Logic.Repositories
{
    public class Cart_productRepository : ICart_productRepository
    {
        public Cart_product Create(DataContext dataContext, Cart_product cart_product)
        {
            dataContext.Cart_products.Add(cart_product);
            return cart_product;
        }

        public Cart_product Update(DataContext dataContext, Cart_product cart_product)
        {
            var cart_productDB = dataContext.Cart_products.FirstOrDefault(x => x.Id == cart_product.Id)
                ?? throw new Exception($"Клиент с данным идентификатором {cart_product.Id} не найден");

            cart_productDB.Id = cart_product.Id;
            cart_productDB.ProductId = cart_product.ProductId;
            cart_productDB.CartId = cart_product.CartId;
            cart_productDB.count = cart_product.count;

            return cart_productDB;
        }

        public void Delete(DataContext dataContext, Guid id)
        {
            var cart_productDB = dataContext.Cart_products.FirstOrDefault(x => x.Id == id)
                ?? throw new Exception($"Клиент с данным идентификатором {id} не найден");

            dataContext.Cart_products.Remove(cart_productDB);
        }

        public Cart_product GetByID(DataContext dataContext, Guid id)
        {
            var cart_productDB = dataContext.Cart_products.AsNoTracking().FirstOrDefault(x => x.Id == id)
                ?? throw new Exception($"Клиент с данным идентификатором {id} не найден");

            // AsNoTracking используется для экономии ресурсов, поскольку такие изменения не отслеживаются.
            return cart_productDB;
        }
    }
}
