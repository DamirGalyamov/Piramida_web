using Piramida.Storage.Database;
using Piramida.Storage.Models;

namespace Piramid.Logic.Interfaces.Repositories
{
    public interface IAdmissionRepository
    {
        Admission Create(DataContext dataContext, Admission admission);

        Admission Update(DataContext dataContext, Admission admission);

        void Delete(DataContext dataContext, Guid IsnNode);

        Admission GetByID(DataContext dataContext, Guid IsnNode);
    }
}
