using AutoMapper;
using Piramid.Logic.Interfaces.Repositories;
using Piramid.Logic.Interfaces.Services;
using Piramida.Logic.DtoModels.Filters;
using Piramida.Storage.Database;
using Piramida.Storage.Models;
using Piramida_web.Features.DtoModels.Feedback;
using Piramida_web.Features.Interface;

namespace Piramida_web.Features.Managers
{
    public class FeedbackManager : IFeedbackManager
    {
        private readonly IMapper _mapper;
        private readonly IFeedbackRepository _feedbackRepository;
        private readonly IFeedbackService _feedbackServices;
        private readonly DataContext _dataContext;

        public FeedbackManager(IFeedbackRepository feedbackRepository, IFeedbackService feedbackServices, DataContext dataContext, IMapper mapper)
        {
            _mapper = mapper;
            _feedbackRepository = feedbackRepository;
            _feedbackServices = feedbackServices;
            _dataContext = dataContext;
        }

        public void Creat(EditFeedbackDto editFeedback)
        {
            var Feedback = _mapper.Map<Feedback>(editFeedback);

            //System.Console.WriteLine($"Случайный Guid: {Feedback.Id}");

            _feedbackRepository.Create(_dataContext, Feedback);

            _dataContext.SaveChanges();

        }

        public void Update(EditFeedbackDto editFeedback)
        {
            var Feedback = _mapper.Map<Feedback>(editFeedback);

            _feedbackRepository.Update(_dataContext, Feedback);

            _dataContext.SaveChanges();
        }

        public void Delete(Guid Id)
        {
            _feedbackRepository.Delete(_dataContext, Id);
            _dataContext.SaveChanges();
        }

        public FeedbackDto GetFeedback(Guid Id)
        {
            var feedback = _feedbackRepository.GetByID(_dataContext, Id);
            return _mapper.Map<FeedbackDto>(feedback);
        }

        public FeedbackDto[] GetListFeedback(FeedbackFilterDto feedbackFilter)
        {
            var feedback = _feedbackServices.GetFeedbackQueryable(_dataContext, feedbackFilter, true)
                .Select(x => new FeedbackDto
                {
                    Id = x.Id,
                    Telephone = x.Telephone,
                    question = x.question

                }).ToArray();
            return feedback;
        }
    }
}
