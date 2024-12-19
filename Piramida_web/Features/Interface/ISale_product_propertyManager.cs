using Piramida.Logic.DtoModels.Filters;
using Piramida_web.Features.DtoModels.Sale_product_property;

namespace Piramida_web.Features.Interface
{
    public interface ISale_product_propertyManager
    {
        public void Creat(EditSale_product_propertyDto editSale_product_property);
        public void Update(EditSale_product_propertyDto editSale_product_property);
        public void Delete(Guid Id);
        public Sale_product_propertyDto GetSale_product_property(Guid Id);
        public Sale_product_propertyDto[] GetListSale_product_property(Sale_product_propertyFilterDto saleFilter);
        public Sale_product_propertyDto[] GetListSale_product_propertyBySale(SaleFilterDto saleFilter);
    }
}
