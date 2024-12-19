using Piramida.Logic.DtoModels.Filters;
using Piramida_web.Features.DtoModels.Feedback;

namespace Piramida_web.Features.Interface
{
    public interface IFeedbackManager
    {
        public void Creat(EditFeedbackDto editFeedback);
        public void Update(EditFeedbackDto editFeedback);
        public void Delete(Guid Id);
        public FeedbackDto GetFeedback(Guid Id);
        public FeedbackDto[] GetListFeedback(FeedbackFilterDto feedbackFilter);
    }
}
