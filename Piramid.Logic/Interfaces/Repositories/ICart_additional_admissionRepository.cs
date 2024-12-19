using Piramida.Storage.Database;
using Piramida.Storage.Models;

namespace Piramid.Logic.Interfaces.Repositories
{
    public interface ICart_additional_admissionRepository
    {
        Cart_additional_admission Create(DataContext dataContext, Cart_additional_admission cart_additional_admission);

        Cart_additional_admission Update(DataContext dataContext, Cart_additional_admission cart_additional_admission);

        void Delete(DataContext dataContext, Guid Id);

        Cart_additional_admission GetByID(DataContext dataContext, Guid Id);
    }
}
