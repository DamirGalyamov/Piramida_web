using Piramida.Logic.DtoModels.Filters;
using Piramida_web.Features.DtoModels.ImagesForSpailn;

namespace Piramida_web.Features.Interface
{
    public interface IImagesForSpailnManager
    {
        public void Creat(EditImagesForSpailnDto editImagesForSpailn);
        public void Update(EditImagesForSpailnDto editImagesForSpailn);
        public void Delete(Guid Id);
        public ImagesForSpailnDto GetImagesForSpailn(Guid Id);
        public ImagesForSpailnDto[] GetListImagesForSpailn(ImageForSplainFilterDto clientFilter);
    }
}
