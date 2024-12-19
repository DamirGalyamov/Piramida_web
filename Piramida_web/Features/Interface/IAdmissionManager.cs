using Piramida.Logic.DtoModels.Filters;
using Piramida_web.Features.DtoModels.Admission;

namespace Piramida_web.Features.Interface
{
    public interface IAdmissionManager
    {
        public void Creat(EditAdmissionDto editAdmission);
        public void Update(EditAdmissionDto editAdmission);
        public void Delete(Guid Id);
        public AdmissionDto GetAdmission(Guid Id);
        public AdmissionDto[] GetListAdmission(AdmissionFilterDto admissionFilter);

        public AdmissionDto[] GetListAdmissionByClient(AdmissionFilterByClient admissionFilter);

        public AdmissionDto[] GetListAdmissionByEmployee(AdmissionFilterByEmployee admissionFilter);
    }
}
