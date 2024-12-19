using Piramida.Logic.DtoModels.Filters;
using Piramida.Storage.Database;
using Piramida.Storage.Models;

namespace Piramid.Logic.Interfaces.Services
{
    public interface IImageForSplainService
    {
        IQueryable<ImagesForSpailn> GetImageForSplainQueryable(DataContext dataContext, ImageForSplainFilterDto filter, bool AsNoTraking);
    }
}
