using Piramida.Logic.DtoModels.Filters;
using Piramida.Storage.Database;
using Piramida.Storage.Models;

namespace Piramid.Logic.Interfaces.Services
{
    public interface ICart_additional_admissionService
    {
        IQueryable<Cart_additional_admission> GetCart_additional_admissionQueryable(DataContext dataContext, Cart_additional_admissionFilterDto filter, bool AsNoTraking);
    }
}