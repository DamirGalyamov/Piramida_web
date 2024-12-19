using AutoMapper;
using Piramid.Logic.Interfaces.Repositories;
using Piramid.Logic.Interfaces.Services;
using Piramida.Logic.DtoModels.Filters;
using Piramida.Storage.Database;
using Piramida.Storage.Models;
using Piramida_web.Features.DtoModels.ImagesForSpailn;
using Piramida_web.Features.Interface;

namespace Piramida_web.Features.Managers
{
    public class ImagesForSpailnManager : IImagesForSpailnManager
    {
        private readonly IMapper _mapper;
        private readonly IImageForSplainRepository _imagesForSpailnRepository;
        private readonly IImageForSplainService _imagesForSpailnServices;
        private readonly DataContext _dataContext;

        public ImagesForSpailnManager(IImageForSplainRepository imagesForSpailnRepository, IImageForSplainService imagesForSpailnServices, DataContext dataContext, IMapper mapper)
        {
            _mapper = mapper;
            _imagesForSpailnRepository = imagesForSpailnRepository;
            _imagesForSpailnServices = imagesForSpailnServices;
            _dataContext = dataContext;
        }

        public void Creat(EditImagesForSpailnDto editImagesForSpailn)
        {
            var ImagesForSpailns = _mapper.Map<ImagesForSpailn>(editImagesForSpailn);

            //System.Console.WriteLine($"Случайный Guid: {ImagesForSpailn.Id}");

            _imagesForSpailnRepository.Create(_dataContext, ImagesForSpailns);

            _dataContext.SaveChanges();

        }

        public void Update(EditImagesForSpailnDto editImagesForSpailn)
        {
            var ImagesForSpailn = _mapper.Map<ImagesForSpailn>(editImagesForSpailn);

            _imagesForSpailnRepository.Update(_dataContext, ImagesForSpailn);

            _dataContext.SaveChanges();
        }

        public void Delete(Guid Id)
        {
            _imagesForSpailnRepository.Delete(_dataContext, Id);
            _dataContext.SaveChanges();
        }

        public ImagesForSpailnDto GetImagesForSpailn(Guid Id)
        {
            var imagesForSpailn = _imagesForSpailnRepository.GetByID(_dataContext, Id);
            return _mapper.Map<ImagesForSpailnDto>(imagesForSpailn);
        }

        public ImagesForSpailnDto[] GetListImagesForSpailn(ImageForSplainFilterDto imagesForSpailnFilter)
        {
            var imagesForSpailn = _imagesForSpailnServices.GetImageForSplainQueryable(_dataContext, imagesForSpailnFilter, true)
                .Select(x => new ImagesForSpailnDto
                {
                    Id = x.Id,
                    Titel = x.Titel,
                    Description = x.Description,
                    ImageUrl = x.ImageUrl,
                    link = x.link,

                }).ToArray();
            return imagesForSpailn;
        }
    }
}
