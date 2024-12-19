using Microsoft.EntityFrameworkCore;
using Piramid.Logic.Interfaces.Repositories;
using Piramida.Storage.Database;
using Piramida.Storage.Models;

namespace Piramid.Logic.Repositories
{
    public class Cart_additional_propertyRepository : ICart_additional_propertyRepository
    {
        public Cart_additional_property Create(DataContext dataContext, Cart_additional_property cart_additional_property)
        {
            dataContext.Cart_Additional_Properties.Add(cart_additional_property);
            return cart_additional_property;
        }

        public Cart_additional_property Update(DataContext dataContext, Cart_additional_property cart_additional_property)
        {
            var cart_additional_propertyDB = dataContext.Cart_Additional_Properties.FirstOrDefault(x => x.Id == cart_additional_property.Id)
                ?? throw new Exception($"Клиент с данным идентификатором {cart_additional_property.Id} не найден");

            cart_additional_propertyDB.Id = cart_additional_property.Id;
            cart_additional_propertyDB.Product_propertyId = cart_additional_property.Product_propertyId;
            cart_additional_propertyDB.Cart_productId = cart_additional_property.Cart_productId;

            return cart_additional_propertyDB;
        }

        public void Delete(DataContext dataContext, Guid id)
        {
            var cart_additional_propertyDB = dataContext.Cart_Additional_Properties.FirstOrDefault(x => x.Id == id)
                ?? throw new Exception($"Клиент с данным идентификатором {id} не найден");

            dataContext.Cart_Additional_Properties.Remove(cart_additional_propertyDB);
        }

        public Cart_additional_property GetByID(DataContext dataContext, Guid id)
        {
            var cart_additional_propertyDB = dataContext.Cart_Additional_Properties.AsNoTracking().FirstOrDefault(x => x.Id == id)
                ?? throw new Exception($"Клиент с данным идентификатором {id} не найден");

            // AsNoTracking используется для экономии ресурсов, поскольку такие изменения не отслеживаются.
            return cart_additional_propertyDB;
        }
    }
}
