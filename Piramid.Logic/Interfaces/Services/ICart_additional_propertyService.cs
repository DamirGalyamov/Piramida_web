using Piramida.Logic.DtoModels.Filters;
using Piramida.Storage.Database;
using Piramida.Storage.Models;

namespace Piramid.Logic.Interfaces.Services
{
    public interface ICart_additional_propertyService
    {
        IQueryable<Cart_additional_property> GetCart_additional_propertyQueryable(DataContext dataContext, Cart_additional_propertyFilterDto filter, bool AsNoTraking);
    }
}