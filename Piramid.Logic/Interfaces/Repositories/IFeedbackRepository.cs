using Piramida.Storage.Database;
using Piramida.Storage.Models;

namespace Piramid.Logic.Interfaces.Repositories
{
    public interface IFeedbackRepository
    {
        Feedback Create(DataContext dataContext, Feedback feedback);

        Feedback Update(DataContext dataContext, Feedback feedback);

        void Delete(DataContext dataContext, Guid isnNode);

        Feedback GetByID(DataContext dataContext, Guid isnNode);
    }
}
