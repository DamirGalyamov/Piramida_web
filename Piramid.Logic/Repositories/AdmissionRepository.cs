using Microsoft.EntityFrameworkCore;
using Piramid.Logic.Interfaces.Repositories;
using Piramida.Storage.Database;
using Piramida.Storage.Models;

namespace Piramid.Logic.Repositories
{
    public class AdmissionRepository : IAdmissionRepository
    {
        public Admission Create(DataContext dataContext, Admission admission)
        {
            //admission.IsnNode = new Guid();
            dataContext.Admissions.Add(admission);

            return admission;

        }

        public Admission Update(DataContext dataContext, Admission admission)
        {
            var AdmissionDB = dataContext.Admissions.FirstOrDefault(x => x.Id == admission.Id)
            ?? throw new Exception($"Запись с данным индификатором {admission.Id} не найдено");

            AdmissionDB.Id = admission.Id;
            AdmissionDB.ProductId = admission.ProductId;
            AdmissionDB.ClientId = admission.ClientId;
            AdmissionDB.EmployeeId = admission.EmployeeId;
            AdmissionDB.Time = admission.Time;
            AdmissionDB.Status = admission.Status;

            return AdmissionDB;

        }

        public void Delete(DataContext dataContext, Guid Id)
        {
            var AdmissionDB = dataContext.Admissions.FirstOrDefault(x => x.Id == Id)
            ?? throw new Exception($"Запись с данным индификатором {Id} не найдено");

            dataContext.Admissions.Remove(AdmissionDB);

        }

        public Admission GetByID(DataContext dataContext, Guid Id)
        {
            var AdmissionDB = dataContext.Admissions.AsNoTracking().FirstOrDefault(x => x.Id == Id)
            ?? throw new Exception($"Запись с данным индификатором {Id} не найдено");

            //аснотрекинг используется для экономии ресурсов, поскольку такие изменения не отслеживуютя, для дальнейшего сохранения

            return AdmissionDB;
        }
    }
}
