using Microsoft.EntityFrameworkCore;
using Piramid.Logic.Interfaces.Services;
using Piramida.Logic.DtoModels.Filters;
using Piramida.Storage.Database;
using Piramida.Storage.Models;

namespace Piramid.Logic.Services
{
    public class ImageForSplainService : IImageForSplainService
    {
        public IQueryable<ImagesForSpailn> GetImageForSplainQueryable(DataContext dataContext, ImageForSplainFilterDto filter, bool AsNoTraking)
        {
            IQueryable<ImagesForSpailn> query = dataContext.ImagesForSpailns;

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
