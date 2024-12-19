using Piramida.Logic.DtoModels.Filters;
using Piramida.Storage.Database;
using Piramida.Storage.Models;

namespace Piramid.Logic.Interfaces.Services
{
    public interface IAdmissionService
    {
        IQueryable<Admission> GetAdmissionQueryable(DataContext dataContext, AdmissionFilterDto filter, bool AsNoTraking);
        IQueryable<Admission> GetAdmissionQueryableByClient(DataContext dataContext, AdmissionFilterByClient filter, bool AsNoTraking);
        IQueryable<Admission> GetAdmissionQueryableByEmployee(DataContext dataContext, AdmissionFilterByEmployee filter, bool AsNoTraking);
    }
}