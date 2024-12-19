using Microsoft.EntityFrameworkCore;
using Piramid.Logic.Interfaces.Services;
using Piramida.Logic.DtoModels.Filters;
using Piramida.Storage.Database;
using Piramida.Storage.Models;

namespace Piramid.Logic.Services
{
    public class AdmissionService : IAdmissionService
    {
        public IQueryable<Admission> GetAdmissionQueryable(DataContext dataContext, AdmissionFilterDto filter, bool AsNoTraking)
        {
            IQueryable<Admission> query = dataContext.Admissions;

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

        public IQueryable<Admission> GetAdmissionQueryableByClient(DataContext dataContext, AdmissionFilterByClient filter, bool AsNoTraking)
        {
            IQueryable<Admission> query = dataContext.Admissions;

            if (AsNoTraking)
            {
                query = query.AsNoTracking();
            }
            if (filter != null)
            {
                query = query.Where(x => x.Id == filter.ClientId);
            }
            return query;
        }

        public IQueryable<Admission> GetAdmissionQueryableByEmployee(DataContext dataContext, AdmissionFilterByEmployee filter, bool AsNoTraking)
        {
            IQueryable<Admission> query = dataContext.Admissions;

            if (AsNoTraking)
            {
                query = query.AsNoTracking();
            }
            if (filter != null)
            {
                query = query.Where(x => x.Id == filter.EmployeeId);
            }
            return query;
        }
    }
}