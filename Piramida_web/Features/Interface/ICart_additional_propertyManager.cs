using Piramida.Logic.DtoModels.Filters;
using Piramida_web.Features.DtoModels.Cart_additional_property;

namespace Piramida_web.Features.Interface
{
    public interface ICart_additional_propertyManager
    {
        public void Creat(EditCart_additional_propertyDto editCart_additional_property);
        public void Update(EditCart_additional_propertyDto editCart_additional_property);
        public void Delete(Guid Id);
        public Cart_additional_propertyDto GetCart_additional_property(Guid Id);
        public Cart_additional_propertyDto[] GetListCart_additional_property(Cart_additional_propertyFilterDto clientFilter);
    }
}
