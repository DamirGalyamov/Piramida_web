using Piramida.Logic.DtoModels.Filters;
using Piramida_web.Features.DtoModels.Sale;

namespace Piramida_web.Features.Interface
{
    public interface ISaleManager
    {
        public void Creat(EditSaleDto editSale);
        public void Update(EditSaleDto editSale);
        public void Delete(Guid Id);
        public SaleDto GetSale(Guid Id);
        public SaleDto[] GetListSale(SaleFilterDto saleFilter);
        public SaleDto[] GetListSaleByProduct(SaleFilterDto saleFilter);
    }
}
