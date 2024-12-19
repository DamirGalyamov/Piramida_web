using Piramida.Logic.DtoModels.Filters;
using Piramida_web.Features.DtoModels.Cart_product;

namespace Piramida_web.Features.Interface
{
    public interface ICart_productManager
    {
        public void Creat(EditCart_productDto editCart_product);
        public void Update(EditCart_productDto editCart_product);
        public void Delete(Guid Id);
        public Cart_productDto GetCart_product(Guid Id);
        public Cart_productDto[] GetListCart_product(Cart_productFilterDto clientFilter);
        public Cart_productDto[] GetListCart_productByCart(Cart_productFilterDto cart_productFilter);
    }
}
