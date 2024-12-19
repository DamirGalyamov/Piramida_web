using Microsoft.EntityFrameworkCore;
using Piramid.Logic.Interfaces.Repositories;
using Piramida.Storage.Database;
using Piramida.Storage.Models;

namespace Piramid.Logic.Repositories
{
    public class Cart_additional_admissionRepository : ICart_additional_admissionRepository
    {
        public Cart_additional_admission Create(DataContext dataContext, Cart_additional_admission cart_additional_admission)
        {
            dataContext.Cart_Additional_Admissions.Add(cart_additional_admission);
            return cart_additional_admission;
        }

        public Cart_additional_admission Update(DataContext dataContext, Cart_additional_admission cart_additional_admission)
        {
            var cart_additional_admissionDB = dataContext.Cart_Additional_Admissions.FirstOrDefault(x => x.Id == cart_additional_admission.Id)
                ?? throw new Exception($"Клиент с данным идентификатором {cart_additional_admission.Id} не найден");

            cart_additional_admissionDB.Id = cart_additional_admission.Id;
            cart_additional_admissionDB.AdmissionId = cart_additional_admission.AdmissionId;
            cart_additional_admissionDB.Cart_productId = cart_additional_admission.Cart_productId;

            return cart_additional_admissionDB;
        }

        public void Delete(DataContext dataContext, Guid id)
        {
            var cart_additional_admissionDB = dataContext.Cart_Additional_Admissions.FirstOrDefault(x => x.Id == id)
                ?? throw new Exception($"Клиент с данным идентификатором {id} не найден");

            dataContext.Cart_Additional_Admissions.Remove(cart_additional_admissionDB);
        }

        public Cart_additional_admission GetByID(DataContext dataContext, Guid id)
        {
            var cart_additional_admissionDB = dataContext.Cart_Additional_Admissions.AsNoTracking().FirstOrDefault(x => x.Id == id)
                ?? throw new Exception($"Клиент с данным идентификатором {id} не найден");

            // AsNoTracking используется для экономии ресурсов, поскольку такие изменения не отслеживаются.
            return cart_additional_admissionDB;
        }
    }
}
