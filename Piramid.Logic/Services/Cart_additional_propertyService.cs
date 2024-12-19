using Microsoft.EntityFrameworkCore;
using Piramid.Logic.Interfaces.Services;
using Piramida.Logic.DtoModels.Filters;
using Piramida.Storage.Database;
using Piramida.Storage.Models;

namespace Piramid.Logic.Services
{
    public class Cart_additional_propertyService : ICart_additional_propertyService
    {
        public IQueryable<Cart_additional_property> GetCart_additional_propertyQueryable(DataContext dataContext, Cart_additional_propertyFilterDto filter, bool AsNoTraking)
        {
            IQueryable<Cart_additional_property> query = dataContext.Cart_Additional_Properties;

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
    }
}
