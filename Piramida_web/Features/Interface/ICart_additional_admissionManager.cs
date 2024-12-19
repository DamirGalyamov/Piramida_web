using Piramida.Logic.DtoModels.Filters;
using Piramida_web.Features.DtoModels.Cart_additional_admission;

namespace Piramida_web.Features.Interface
{
    public interface ICart_additional_admissionManager
    {
        public void Creat(EditCart_additional_admissionDto editCart_additional_admission);
        public void Update(EditCart_additional_admissionDto editCart_additional_admission);
        public void Delete(Guid Id);
        public Cart_additional_admissionDto GetCart_additional_admission(Guid Id);
        public Cart_additional_admissionDto[] GetListCart_additional_admission(Cart_additional_admissionFilterDto clientFilter);
    }
}
