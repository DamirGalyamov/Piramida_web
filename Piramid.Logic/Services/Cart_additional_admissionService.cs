using Microsoft.EntityFrameworkCore;
using Piramid.Logic.Interfaces.Services;
using Piramida.Logic.DtoModels.Filters;
using Piramida.Storage.Database;
using Piramida.Storage.Models;

namespace Piramid.Logic.Services
{
    public class Cart_additional_admissionService : ICart_additional_admissionService
    {
        public IQueryable<Cart_additional_admission> GetCart_additional_admissionQueryable(DataContext dataContext, Cart_additional_admissionFilterDto filter, bool AsNoTraking)
        {
            IQueryable<Cart_additional_admission> query = dataContext.Cart_Additional_Admissions;

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
