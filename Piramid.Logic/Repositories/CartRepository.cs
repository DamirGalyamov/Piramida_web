using Microsoft.EntityFrameworkCore;
using Piramid.Logic.Interfaces.Repositories;
using Piramida.Storage.Database;
using Piramida.Storage.Models;

namespace Piramid.Logic.Repositories
{
    public class CartRepository : ICartRepository
    {
        public Cart Create(DataContext dataContext, Cart cart)
        {
            dataContext.Carts.Add(cart);
            return cart;
        }

        public Cart Update(DataContext dataContext, Cart cart)
        {
            var cartDB = dataContext.Carts.FirstOrDefault(x => x.Id == cart.Id)
                ?? throw new Exception($"Клиент с данным идентификатором {cart.Id} не найден");

            cartDB.ClientId = cart.ClientId;
            cartDB.Id = cart.Id;

            return cartDB;
        }

        public void Delete(DataContext dataContext, Guid id)
        {
            var cartDB = dataContext.Carts.FirstOrDefault(x => x.Id == id)
                ?? throw new Exception($"Клиент с данным идентификатором {id} не найден");

            dataContext.Carts.Remove(cartDB);
        }

        public Cart GetByID(DataContext dataContext, Guid id)
        {
            var cartDB = dataContext.Carts.AsNoTracking().FirstOrDefault(x => x.Id == id)
                ?? throw new Exception($"Клиент с данным идентификатором {id} не найден");

            // AsNoTracking используется для экономии ресурсов, поскольку такие изменения не отслеживаются.
            return cartDB;
        }
    }
}
