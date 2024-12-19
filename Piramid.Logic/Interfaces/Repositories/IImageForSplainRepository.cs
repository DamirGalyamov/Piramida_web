using Piramida.Storage.Database;
using Piramida.Storage.Models;

namespace Piramid.Logic.Interfaces.Repositories
{
    public interface IImageForSplainRepository
    {
        ImagesForSpailn Create(DataContext dataContext, ImagesForSpailn client);

        ImagesForSpailn Update(DataContext dataContext, ImagesForSpailn client);

        void Delete(DataContext dataContext, Guid IsnNode);

        ImagesForSpailn GetByID(DataContext dataContext, Guid IsnNode);

    }
}
