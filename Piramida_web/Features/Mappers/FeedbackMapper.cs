using AutoMapper;
using Piramida.Storage.Models;
using Piramida_web.Features.DtoModels.Feedback;

namespace Piramida_web.Features.Mappers
{
    public class FeedbackMapper : Profile
    {
        public FeedbackMapper()
        {
            CreateMap<FeedbackDto, Feedback>();
            CreateMap<Feedback, FeedbackDto>();

            CreateMap<FeedbackDto[], Feedback[]>();
            CreateMap<Feedback[], FeedbackDto[]>();

            CreateMap<EditFeedbackDto, Feedback>();
            CreateMap<Feedback, EditFeedbackDto>();
        }
    }
}
