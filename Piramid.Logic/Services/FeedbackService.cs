using Microsoft.EntityFrameworkCore;
using Piramid.Logic.Interfaces.Services;
using Piramida.Logic.DtoModels.Filters;
using Piramida.Storage.Database;
using Piramida.Storage.Models;

namespace Piramid.Logic.Services
{
    public class FeedbackService : IFeedbackService
    {
        public IQueryable<Feedback> GetFeedbackQueryable(DataContext dataContext, FeedbackFilterDto filter, bool AsNoTraking)
        {
            IQueryable<Feedback> query = dataContext.Feedbacks;

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
