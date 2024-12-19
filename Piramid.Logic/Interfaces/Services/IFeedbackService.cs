using Piramida.Logic.DtoModels.Filters;
using Piramida.Storage.Database;
using Piramida.Storage.Models;

namespace Piramid.Logic.Interfaces.Services
{
    public interface IFeedbackService
    {
        IQueryable<Feedback> GetFeedbackQueryable(DataContext dataContext, FeedbackFilterDto filter, bool AsNoTraking);
    }
}
