using Microsoft.EntityFrameworkCore;
using Piramid.Logic.Interfaces.Repositories;
using Piramida.Storage.Database;
using Piramida.Storage.Models;

namespace Piramid.Logic.Repositories
{
    public class FeedbackRepository : IFeedbackRepository
    {
        public Feedback Create(DataContext dataContext, Feedback feedback)
        {
            dataContext.Feedbacks.Add(feedback);
            return feedback;
        }

        public Feedback Update(DataContext dataContext, Feedback feedback)
        {
            var feedbackDB = dataContext.Feedbacks.FirstOrDefault(x => x.Id == feedback.Id)
                ?? throw new Exception($"Отзыв с данным идентификатором {feedback.Id} не найден");

            feedbackDB.Telephone = feedback.Telephone;
            feedbackDB.question = feedback.question;

            return feedbackDB;
        }

        public void Delete(DataContext dataContext, Guid id)
        {
            var feedbackDB = dataContext.Feedbacks.FirstOrDefault(x => x.Id == id)
                ?? throw new Exception($"Отзыв с данным идентификатором {id} не найден");

            dataContext.Feedbacks.Remove(feedbackDB);
        }

        public Feedback GetByID(DataContext dataContext, Guid id)
        {
            var feedbackDB = dataContext.Feedbacks.AsNoTracking().FirstOrDefault(x => x.Id == id)
                ?? throw new Exception($"Отзыв с данным идентификатором {id} не найден");

            // AsNoTracking используется для экономии ресурсов, поскольку такие изменения не отслеживаются.
            return feedbackDB;
        }
    }
}
